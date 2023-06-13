using System.ComponentModel.DataAnnotations;
public class AddressDTO
{
    public string CEP { get; set; }
    public string Logradouro { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }
    public string UF { get; set; }
    public string IBGE { get; set; }
    public string GIA { get; set; }
    public string DDD { get; set; }
    public string Siafi { get; set; }
}
