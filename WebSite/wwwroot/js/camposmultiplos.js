(function () {
    var containers = {};

    // Armazena os htmls
    $('button[data-camposmultiplos-adicionar]').each(function (index, element) {
        var container = $(this).data('camposmultiplos-dados');
        var html = $('.' + container).first().html();
        containers[container] = html;
        if ($('.' + container).hasClass('hidden'))
            $('.' + container).remove();
    });

    // Adiciona um novo item
    $('button[data-camposmultiplos-adicionar]').on('click', function () {
        var container = $(this).data('camposmultiplos-dados');
        var containerPrincipal = $(this).data('camposmultiplos-container');
        var html = containers[container];
        $('.' + containerPrincipal).append('<div class="' + container + '">' + html + '</div>');
        $('.' + container).last()
            .find('input[type=text], input[type=hidden], textarea, select').val('')
            .find('input:checkbox', 'input:radio').removeAttr('checked');
        ReordenarCampos('.' + container);        
    });

    // Removo um item
    $(document).on('click', 'button[data-camposmultiplos-excluir]', function () {
        var container = $(this).data('camposmultiplos-dados');
        $(this).closest('.' + container).remove();
        ReordenarCampos('.' + container);
    });

    $(document).on('click', '.jquery-buscar-endereco', function () {
        var container = $(this).closest('.jquery-campos-enderecos');
        var cep = $(container).find('.jquery-buscar-endereco-cep').val();
        if (cep && cep.length === 9) {
            $.getJSON("https://viacep.com.br/ws/" + cep.replace('-', '') + "/json/?callback=?", function (dados) {
                if (!("erro" in dados)) {
                    $(container).find('.jquery-buscar-endereco-localizacao').val(dados.logradouro);
                    $(container).find('.jquery-buscar-endereco-ufcodigo').val(dados.uf);
                    $(container).find('.jquery-buscar-endereco-bairro').val(dados.bairro);
                    $(container).find('.jquery-buscar-endereco-cidade').val(dados.localidade);
                    $(container).find('.jquery-buscar-endereco-ufcodigo').val();                    
                    $(container).find('.jquery-buscar-endereco-Ibge').val(dados.ibge);
                    $(container).find('option:selected').removeAttr('selected');
                    $(container).find('option:contains(' + dados.uf + ')').attr('selected', 'selected');                   
                }
                else {
                    fw.alert.error('CEP não encontrado !');
                }
            });
        }
        else {
            fw.alert.error('Informe o CEP completo !');
        }
    });


    //$(document).on('change', '.jquery-validar-cpf', function () {
    //    var container = $(this).closest('.jquery-campo');
    //    var cpf = $(container).val();
    //    if (cpf && cpf.length === 14) {
    //        $.getJSON("http://localhost:50620/api/default/get/?cpf=" + cpf.replace('-', '').replace('.',''), function (dados) {
    //            if (("false" in dados)) {
    //                fw.alert.error('CPF não encontrado !');
    //            }
    //        });
    //    }
    //    else {
    //        fw.alert.error('Informe o CPF completo !');
    //    }
    //});

    // Reordena os indices
    function ReordenarCampos(container) {
        var indice = 0;
        $(container).each(function (index, element) {
            $('input,select', $(this)).each(function (index, element) {
                $(this).attr('name', $(this).attr('name').replace(/(\[).+?(\])/g, '$1' + indice + '$2'));
                $(this).attr('id', $(this).attr('id').replace(/(_).+?(__)/g, '$1' + indice + '$2'));
            });
            if (indice > 0)
                $('button[data-camposmultiplos-excluir]', $(this)).removeClass('hidden');
            indice++;
        });
    }
})();