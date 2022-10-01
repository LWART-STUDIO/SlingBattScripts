namespace Custom.Data
{
    public static class CardsExtension
    {
        public static void ResetCardData(this CardData cardData, string fileName)
        {
            cardData.Level = new Engine.Data.FieldKey<int>("Level", fileName, cardData.initLevel);
            cardData.CountOfCards = new Engine.Data.FieldKey<int>("CountOfCards", fileName, cardData.initCount);
            cardData.InInvenory = new Engine.Data.FieldKey<bool>("InInventory", fileName, cardData.initInInventory);
        }

        public static void UnlockCardData(this CardData cardData, string fileName)
        {
            cardData.Level = new Engine.Data.FieldKey<int>("Level", fileName, 30);
            cardData.CountOfCards = new Engine.Data.FieldKey<int>("CountOfCards", fileName, 100000000);
            cardData.InInvenory = new Engine.Data.FieldKey<bool>("InInventory", fileName, true);
        }
    }
}
