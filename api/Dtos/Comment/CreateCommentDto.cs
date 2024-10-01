using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Baslik en az 5 karakter olmalıdır")]
        [MaxLength(20, ErrorMessage = "Baslik 20 karakterden büyük olamaz")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "İcerik en az 5 karakter olmalıdır")]
        [MaxLength(280, ErrorMessage = "İcerik 280 karakterden büyük olamaz")]
        public string Content { get; set; } = string.Empty;

    }
}