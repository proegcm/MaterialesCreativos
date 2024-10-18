using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace ServiciosMC.Mcreativos
{
    
    public class EstadosPedido
    {
         
        // Método que devuelve el mapa de categorías
        public Dictionary<string, string> ObtenerCategoryMap()
        {
            var categoryMap = new Dictionary<string, string>
            {
                { "En producción", "production" },
                { "Envío por Mensajería", "courier" },
                { "Envío por Paquetería", "parcel" },
                { "Entregado", "delivered" },
                { "Devuelto", "returned" },
                { "Anulado", "canceled" },
                { "Completado", "completed" },
                { "Recoge en oficina", "pickup" },
            { "Reprogramar", "rescheduled" }
            };

            return categoryMap;
        }

        // Método que devuelve el mapa de conversión de inglés a español
        public Dictionary<string, string> ObtenerEntospaMap()
        {
            var entospa = new Dictionary<string, string>
        {
            { "production", "En producción" },
            { "courier", "Envío por Mensajería" },
            { "parcel", "Envío por Paquetería" },
            { "delivered", "Entregado" },
            { "returned", "Devuelto" },
            { "canceled", "Anulado" },
            { "completed", "Completado" },
            { "pickup", "Recoge en oficina" },
            { "rescheduled", "Reprogramar" }
        };

            return entospa;
        }

        

       
    }
}
