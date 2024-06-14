using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Stock.Management.Api.Models
{
    /// <summary>
    /// Dados do produto.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ProductModel
    {
        /// <summary>
        /// Nome do produto.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Data de maturidade do produto.
        /// </summary>
        /// 
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime Maturitydate { get; set; }

        /// <summary>
        /// Preõ do produto.
        /// </summary>
        /// 
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal Price { get; set; }
    }
}
