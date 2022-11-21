namespace ApiEverest.Entities
{
    public static class StringExtensions
    {
        public static string CpfFormatter( this string cpf) 

        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }
       
    }
}
