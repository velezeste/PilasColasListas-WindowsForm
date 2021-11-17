using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasColasListas.Mundo
{
    public class PilaAcueducto
    {
        public String Factura { get; set; }
        public String Matricula { get; set; }
        public String Mes { get; set; }
        public String Nombre { get; set; }
        public string Direccion { get; set; }
        public string Estrato { get; set; }
        public string Categoria { get; set; }
        public double Metros { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
        public double Recaudo { get; set; }

        public double CalcularTotal(double metros)
        {            
            double total = metros * 1500;
            return total;
        }
        public double SumaRecaudo(double total, double recaudo)
        {
            total = total + recaudo;
            return total;
        }        
    }
}
