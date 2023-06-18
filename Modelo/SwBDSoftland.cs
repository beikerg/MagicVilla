using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla.Modelo
{
    public class SwBDSoftland
    {
        [Key]
        public int IdBase { get; set; }

        public string? Nombre { get; set; }

        public string? Dblink { get; set; }

        public int? Vigente { get; set; }

       // public string? LinkedServer { get; set; }
    }

    [Table("meses", Schema = "softland")]
    public class Mesess
    {

       
        [Key]
        public string? Mes { get; set; }

        public string? Nombre { get; set; }
    }

    [Table("sw_personal", Schema = "softland")]
    public class Personal
    {
        [Key]
        public string? ficha { get; set; }
        public string? codBancoSuc { get; set; }
       // public string? codEstudios { get; set; }
       // public string? codCajaCompens { get; set; }
        public string? nombres { get; set; }
        public string? rut { get; set; }
        public string? direccion { get; set; }
       // public string? codComuna { get; set; }
       // public string? codCiudad { get; set; }
       // public string? telefono1 { get; set; }
       // public string? telefono2 { get; set; }
       // public string? telefono3 { get; set; }
       // public string? fax { get; set; }
       // public DateTime? fechaNacimient { get; set; }
       //public string? sexo { get; set; }
       // public string? estadoCivil { get; set; }
       // public string? nacionalidad { get; set; }
       // public string? situacionMilit { get; set; }
       // public int? numCargasSimp { get; set; }
       // public int? numCargasInval { get; set; }
       // public int? numCargasMater { get; set; }
       //public DateTime? fechaIngreso { get; set; }
       //public DateTime? fechaPrimerCon { get; set; }
       //public DateTime? fechaContratoV { get; set; }
       //public string codINE { get; set; }
       //public DateTime? fechaFiniquito { get; set; }
       //public string? tipoPago { get; set; }
       //public string? formPagoAntic { get; set; }
       //public string? formPagoLiquiM { get; set; }
       //public string? formPagoRentAc { get; set; }
       //public string? formPagoFiniq { get; set; }
       //public string? tipoCotizIsapr { get; set; }
       //public string? adicional2pcie { get; set; }
       //public string? AdicSegAFP { get; set; }
       //public string? codExCaja { get; set; }
       public string? numCtaCte { get; set; }
       //public string? numTarjetaConH { get; set; }
       //public string? certSueldos { get; set; }
       //public string? certHonorar { get; set; }
       //public string? certHonorPart { get; set; }
       //public string? foto { get; set; }
       //public string? firma { get; set; }
       //public string? rentaAccesoria { get; set; }
       public string? appaterno { get; set; }
       public string? apmaterno { get; set; }
       public string? nombre { get; set; }
       public string? Email { get; set; }
       //public string? WebSite { get; set; }
       //public DateTime? FecCalVac { get; set; }
       //public int? AnoOtraEm { get; set; }
       //public string? CodSucurBan { get; set; }
       //public string? TipoDeposito { get; set; }
       //public string? TipoVvista { get; set; }
       //public string? CodTipEfe { get; set; }
       //public DateTime? FecCertVacPro { get; set; }
       //public string? RolPrivado { get; set; }
       //public DateTime? FecTermContrato { get; set; }
       //public string? Usuario { get; set; }
       //public int? Id_ArchivoFoto { get; set; }
       //public int? Id_ArchivoFirma { get; set; }
       //public int? ActivoPortal { get; set; }
       //public string? UsuarioOT { get; set; }
       //public string? JefeDirecto { get; set; }
       //public string? Art145L { get; set; }
        //public string? Anexo { get; set; }

    }


    public class Tienda
    {
        [Key]
        public int id { get; set; }

        public string? descripcion { get; set; }


        public decimal? precio { get; set; }
    }
}