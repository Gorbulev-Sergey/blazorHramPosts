using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramPosts.Models
{
    public enum type
    {
        [Display(Name = "Новость")]
        новость,
        [Display(Name = "Cтатья")]
        статья,
        [Display(Name = "Видео")]
        видео,
        [Display(Name = "Объявление")]
        объявление
    }
}
