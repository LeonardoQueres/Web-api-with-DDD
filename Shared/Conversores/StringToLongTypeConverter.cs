using AutoMapper;
using System;

namespace Shared.Conversores
{
    // Automapper string to long
    public class StringToLongTypeConverter : ITypeConverter<string, long>
    {
        public long Convert(string source, long destination, ResolutionContext context)
        {
            if (source == null)
                throw new ArgumentNullException(Textos.Shared_Mensagem_Erro_String_To_Int64);
            else
                return long.Parse(source);
        }
    }
}
