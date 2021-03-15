using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class PrecipitationSummaryModel
    {
        [Display(Name = "Última Hora")]
        public MetricModel PastHour { get; set;}

        [Display(Name = "Últimas 12 Horas")]
        public MetricModel Past12Hours { get; set; }

        [Display(Name = "Últimas 24 Horas")]
        public MetricModel Past24Hours { get; set; }

    }
}