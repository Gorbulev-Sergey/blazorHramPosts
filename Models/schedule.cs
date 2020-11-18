using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;

namespace blazorHramPosts.Models
{  
    [Table(name: "schedule")]
    public class schedule_string
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Дата и время")]
        public DateTime date_and_time { get; set; }
        /// <summary>
        /// Праздник
        /// </summary>
        [Display(Name = "Праздник")]
        public string description { get; set; }
        /// <summary>
        /// Служба
        /// </summary>
        [Display(Name = "Служба")]
        public тип_службы prayer { get; set; }
        [Display(Name ="Цвет или формат текста")]
        public тип_праздника тип_праздника { get; set; }

        /// <summary>
        /// Метод, который позволяет получить значение атрибута "description" для этого enum
        /// </summary>
        public static string GetDescription(Enum enumElement)
        {
            Type type = enumElement.GetType();

            MemberInfo[] memInfo = type.GetMember(enumElement.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return enumElement.ToString();
        }
    }

    public enum тип_службы
    {
        [Description("")]
        пусто=0,
        [Description("Литургия")]
        Литургия=1,
        [Description("Всенощное бдение")]
        Всенощное_бдение=2,
        [Description("Молебен")]
        Молебен=3,
        [Description("Акафист")]
        Акафист=4,
        [Description("Панихида")]
        Панихида=5,
        [Description("Литургия, молебен")]
        Литургия_и_молебен=6,
        [Description("Литургия, панихида")]
        Литургия_и_панихида=7,
        [Description("Молебен с акафистом")]
        Молебен_с_акафистом=8
    }

    public enum тип_праздника
    {
        [Description("")]
        пусто =0,
        [Description("жирный")]
        жирный =1,
        [Description("курсив")]
        курсив =2,
        [Description("жирный заглавный")]
        жирный_заглавный =3,
        [Description("primary")]
        primary =4
    }
}
