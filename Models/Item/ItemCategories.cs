namespace PositronAPI.Models.Item
{
    public enum ItemCategories
    {
        // Barbershop Categories
        Haircuts,
        Shaving,
        HairStyling,
        HaircareProducts,
        SkincareProducts,
        BarberServices, // for other general services

        // Restaurant Categories
        Appetizers,
        MainCourses,
        Desserts,
        Beverages,
        AlcoholicDrinks,
        NonAlcoholicDrinks,
        SpecialtyDishes, // for signature or unique dishes

        // Common Categories
        Merchandise, // like branded items, t-shirts, etc.
        Memberships, // for subscription or loyalty programs
        SpecialOffers // for promotions or special deals
    }
}
