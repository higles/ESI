namespace ESI
{
    /// <summary>
    /// Market ESI urls
    /// </summary>
    public static class Market
    {
        #region Urls
        /// <summary>
        /// List open market orders placed by a character
        /// </summary>
        /// <param name="characterId">Character id</param>
        /// <returns>Url for retrieving orders placed by the given character</returns>
        public static string ListOpenOrdersFromACharacter(long characterId)
        {
            return $"https://esi.evetech.net/v2/characters/{characterId}/orders/?datasource=tranquility";
        }

        /// <summary>
        /// List cancelled and expired market orders placed by a character up to 90 days in the past.
        /// </summary>
        /// <param name="characterId">Character id</param>
        /// <param name="page">Page number</param>
        /// <returns>Url for retrieving cancelled and expired orders placed by the given character</returns>
        public static string ListHistoricalOrdersByACharacter(long characterId, int page = 1)
        {
            return $"https://esi.evetech.net/v1/characters/{characterId}/orders/history/?datasource=tranquility&page={page}";
        }

        /// <summary>
        /// List open market orders placed on behalf of a corporation
        /// </summary>
        /// <param name="corporationId">Corporation id</param>
        /// <param name="page">Page number</param>
        /// <returns>Url for retrieving orders placed by the given corporation</returns>
        public static string ListOpenOrdersFromACorporation(int corporationId, int page = 1)
        {
            return $"https://esi.evetech.net/v3/corporations/{corporationId}/orders/?datasource=tranquility&page={page}";
        }

        /// <summary>
        /// List cancelled and expired market orders placed on behalf of a corporation up to 90 days in the past.
        /// </summary>
        /// <param name="corporationId">Corporation id</param>
        /// <param name="page">Page number</param>
        /// <returns>Url for retrieving cancelled and expired orders placed by the given corporation</returns>
        public static string ListHistoricalOrdersFromACorporation(int corporationId, int page = 1)
        {
            return $"https://esi.evetech.net/v2/corporations/{corporationId}/orders/history/?datasource=tranquility&page={page}";
        }

        /// <summary>
        /// Get a list of item groups
        /// </summary>
        /// <returns>Url for retrieving a list of item groups</returns>
        public static string GetItemGroups()
        {
            return $"https://esi.evetech.net/v1/markets/groups/?datasource=tranquility";
        }

        /// <summary>
        /// Get information on an item group
        /// </summary>
        /// <param name="marketGroupId">Market group id</param>
        /// <returns>Url for retrieving information for a given market group</returns>
        public static string GetItemGroupInformation(int marketGroupId)
        {
            return $"https://esi.evetech.net/v1/markets/groups/{marketGroupId}/?datasource=tranquility&language=en-us";
        }

        /// <summary>
        /// Get a list of prices
        /// </summary>
        /// <returns>Url for retrieving a list of market prices</returns>
        public static string ListMarketPrices()
        {
            return "https://esi.evetech.net/latest/markets/prices/?datasource=tranquility";
        }

        /// <summary>
        /// Get orders in a structure
        /// </summary>
        /// <param name="structureId">Structure id</param>
        /// <param name="page">Page number</param>
        /// <returns>Url for retrieving orders in a given structure</returns>
        public static string ListOrdersInAStructure(int structureId, int page = 1)
        {
            return $"https://esi.evetech.net/v1/markets/structures/{structureId}/?datasource=tranquility&page={page}";
        }

        /// <summary>
        /// Get a list of historical market statistics for a specified type in a region.
        /// </summary>
        /// <param name="regionId">Region id</param>
        /// <param name="marketTypeId">Market type id</param>
        /// <returns>Url for retrieving market statistics for a specified type in a region</returns>
        public static string ListHistoricalMarketStatisticsInARegion(int regionId, int marketTypeId)
        {
            return $"https://esi.evetech.net/v1/markets/{regionId}/history/?datasource=tranquility&type_id={marketTypeId}";
        }

        /// <summary>
        /// Get a list of orders in a region.
        /// Optionally you can specify a market type.
        /// </summary>
        /// <param name="regionId">Region id</param>
        /// <param name="marketTypeId">Market type id</param>
        /// <param name="page">Page number</param>
        /// <returns>Url for retrieving a list of orders in a given region</returns>
        public static string ListOrdersInARegion(int regionId, int? marketTypeId = null, int page = 1)
        {
            return $"https://esi.evetech.net/v1/markets/{regionId}/orders/?datasource=tranquility&order_type=all&page={page}&type_id={marketTypeId}";
        }

        /// <summary>
        /// Return a list of type IDs that have active orders in the region, for efficient market indexing.
        /// </summary>
        /// <param name="regionId">Region id</param>
        /// <param name="page">Page number</param>
        /// <returns>Url for retrieving a list of type IDs with active orders in a given region</returns>
        public static string ListTypeIdsReleventToAMarket(int regionId, int page = 1)
        {
            return $"https://esi.evetech.net/v1/markets/{regionId}/types/?datasource=tranquility&page={page}";
        }
        #endregion
    }
}
