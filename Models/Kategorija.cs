using System.ComponentModel.DataAnnotations;

public enum Kategorija

{
    [Display(Name = "Mesni proizvodi")]
    meso,

    [Display(Name = "Grickalice")]
    cips,

    [Display(Name = "Slatko")]
    cokolada,

    [Display(Name = "Mlijecni proizvodi")]
    mlijeko,

    [Display(Name = "Gazirana pica")]
    cola,

    [Display(Name = "Negazirana pica")]
    sok,

    [Display(Name = "Alkoholna pica")]
    Alkohol
}
