using ESI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public static string ListOrdersInAStructure(long structureId, int page = 1)
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

        #region Data Queries
        #region Order
        /// <summary>
        /// List open market orders placed by a character
        /// </summary>
        /// <param name="characterId">Character id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOpenOrdersFromACharacterAsync (long characterId)
        {
            var url = ListOpenOrdersFromACharacter(characterId);
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsArrayAsync<Order>(responses.ElementAt(0));
        }

        /// <summary>
        /// List open market orders placed by a set of character
        /// </summary>
        /// <param name="characterIds">Character ids</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOpenOrdersFromACharacterAsync(IEnumerable<long> characterIds)
        {
            var urls = new List<string>();
            foreach (var id in characterIds)
            {
                urls.Add(ListOpenOrdersFromACharacter(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);

            return await ESI.ReadResponsesAsArraysAsync<Order>(responses);
        }

        /// <summary>
        /// List cancelled and expired market orders placed by a character up to 90 days in the past.
        /// </summary>
        /// <param name="characterId">Character id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListHistoricalOrdersByACharacterAsync(long characterId)
        {
            int i = 0;
            List<string> urls;
            IEnumerable<Order> responseOrders = new List<Order>();
            List<Order> orders = new List<Order>();

            do
            {
                urls = new List<string>();
                urls.Add(ListHistoricalOrdersByACharacter(characterId, (i * 5) + 1));
                urls.Add(ListHistoricalOrdersByACharacter(characterId, (i * 5) + 2));
                urls.Add(ListHistoricalOrdersByACharacter(characterId, (i * 5) + 3));
                urls.Add(ListHistoricalOrdersByACharacter(characterId, (i * 5) + 4));
                urls.Add(ListHistoricalOrdersByACharacter(characterId, (i * 5) + 5));

                var responses = await ESI.MakeEsiRequestsAsync(urls);

                responseOrders = await ESI.ReadResponsesAsArraysAsync<Order>(responses);
                orders.AddRange(responseOrders);

                i++;
            } while (responseOrders.Count() >= 5000);

            return orders;
        }

        /// <summary>
        /// List open market orders placed on behalf of a corporation
        /// </summary>
        /// <param name="corporationId">CorporationId</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOpenOrdersFromACorporationAsync(int corporationId)
        {
            int i = 0;
            List<string> urls;

            IEnumerable<Order> responseOrders = new List<Order>();
            List<Order> orders = new List<Order>();

            do
            {
                urls = new List<string>();
                urls.Add(ListOpenOrdersFromACorporation(corporationId, (i * 5) + 1));
                urls.Add(ListOpenOrdersFromACorporation(corporationId, (i * 5) + 2));
                urls.Add(ListOpenOrdersFromACorporation(corporationId, (i * 5) + 3));
                urls.Add(ListOpenOrdersFromACorporation(corporationId, (i * 5) + 4));
                urls.Add(ListOpenOrdersFromACorporation(corporationId, (i * 5) + 5));

                var responses = await ESI.MakeEsiRequestsAsync(urls);

                responseOrders = await ESI.ReadResponsesAsArraysAsync<Order>(responses);
                orders.AddRange(responseOrders);

                i++;
            } while (responseOrders.Count() >= 5000);

            return orders;
        }

        /// <summary>
        /// List cancelled and expired market orders placed on behalf of a corporation up to 90 days in the past.
        /// </summary>
        /// <param name="corporationId">Corporation id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListHistoricalOrdersFromACorporationAsync(int corporationId)
        {
            int i = 0;
            List<string> urls;

            IEnumerable<Order> responseOrders = new List<Order>();
            List<Order> orders = new List<Order>();

            do
            {
                urls = new List<string>();
                urls.Add(ListHistoricalOrdersFromACorporation(corporationId, (i * 5) + 1));
                urls.Add(ListHistoricalOrdersFromACorporation(corporationId, (i * 5) + 2));
                urls.Add(ListHistoricalOrdersFromACorporation(corporationId, (i * 5) + 3));
                urls.Add(ListHistoricalOrdersFromACorporation(corporationId, (i * 5) + 4));
                urls.Add(ListHistoricalOrdersFromACorporation(corporationId, (i * 5) + 5));

                var responses = await ESI.MakeEsiRequestsAsync(urls);

                responseOrders = await ESI.ReadResponsesAsArraysAsync<Order>(responses);
                orders.AddRange(responseOrders);

                i++;
            } while (responseOrders.Count() >= 5000);

            return orders;
        }

        /// <summary>
        /// Get orders in a structure
        /// </summary>
        /// <param name="structureId">Structure id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInAStructureAsync(long structureId)
        {
            int i = 0;
            List<string> urls;
            IEnumerable<Order> responseOrders = new List<Order>();
            List<Order> orders = new List<Order>();

            do
            {
                urls = new List<string>();
                urls.Add(ListOrdersInAStructure(structureId, (i * 5) + 1));
                urls.Add(ListOrdersInAStructure(structureId, (i * 5) + 2));
                urls.Add(ListOrdersInAStructure(structureId, (i * 5) + 3));
                urls.Add(ListOrdersInAStructure(structureId, (i * 5) + 4));
                urls.Add(ListOrdersInAStructure(structureId, (i * 5) + 5));

                var responses = await ESI.MakeEsiRequestsAsync(urls);

                responseOrders = await ESI.ReadResponsesAsArraysAsync<Order>(responses);
                orders.AddRange(responseOrders);

                i++;
            } while (responseOrders.Count() >= 5000);

            return orders;
        }

        /// <summary>
        /// Get a list of orders in a region.
        /// Optionally you can specify a market type.
        /// </summary>
        /// <param name="regionId">Region id</param>
        /// <param name="marketTypeId">Market type id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInARegionAsync(int regionId, int? marketTypeId = null)
        {
            int i = 0;
            List<string> urls;

            IEnumerable<Order> responseOrders = new List<Order>();
            List<Order> orders = new List<Order>();

            do
            {
                urls = new List<string>();
                urls.Add(ListOrdersInARegion(regionId, marketTypeId, (i * 3) + 1));
                urls.Add(ListOrdersInARegion(regionId, marketTypeId, (i * 3) + 2));
                urls.Add(ListOrdersInARegion(regionId, marketTypeId, (i * 3) + 3));

                var responses = await ESI.MakeEsiRequestsAsync(urls);

                responseOrders = await ESI.ReadResponsesAsArraysAsync<Order>(responses);
                orders.AddRange(responseOrders);

                i++;
            } while (responseOrders.Count() >= 3000);

            return orders;
        }

        /// <summary>
        /// Get a list of orders in a region.
        /// Optionally you can specify a market type.
        /// </summary>
        /// <param name="regionId">Region id</param>
        /// <param name="marketTypeIds">Market type ids</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInARegionAsync(int regionId, IEnumerable<int> marketTypeIds)
        {
            int i = 0;
            List<string> urls;
            var typeIds = await ListTypeIdsReleventToAMarketAsync(regionId);
            typeIds = typeIds.Where(t => marketTypeIds.Any(m => m == t));

            IEnumerable<Order> responseOrders = new List<Order>();
            List<Order> orders = new List<Order>();

            do
            {
                urls = new List<string>();

                foreach (var id in typeIds)
                {
                    urls.Add(ListOrdersInARegion(regionId, id, (i * 3) + 1));
                    urls.Add(ListOrdersInARegion(regionId, id, (i * 3) + 2));
                    urls.Add(ListOrdersInARegion(regionId, id, (i * 3) + 3));
                }

                var responses = await ESI.MakeEsiRequestsAsync(urls);

                responseOrders = await ESI.ReadResponsesAsArraysAsync<Order>(responses);
                orders.AddRange(responseOrders);

                // update list of type IDs
                List<int> typesOver3k = responseOrders.GroupBy(o => o.TypeID).Where(g => g.Count() >= 3000).Select(g => g.Key).ToList();
                typeIds = typesOver3k;

                i++;
            } while (typeIds.Count() > 0);

            return orders;
        }

        /// <summary>
        /// Get a list of orders in a set of regions.
        /// Optionally you can specify a market type.
        /// </summary>
        /// <param name="regionIds">Region ids</param>
        /// <param name="marketTypeId">Market type id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInARegionAsync(IEnumerable<int> regionIds, int? marketTypeId)
        {
            int i = 0;
            List<string> urls;

            IEnumerable<Order> responseOrders = new List<Order>();
            List<Order> orders = new List<Order>();

            do
            {
                urls = new List<string>();

                foreach (var id in regionIds)
                {
                    urls.Add(ListOrdersInARegion(id, marketTypeId, (i * 3) + 1));
                    urls.Add(ListOrdersInARegion(id, marketTypeId, (i * 3) + 2));
                    urls.Add(ListOrdersInARegion(id, marketTypeId, (i * 3) + 3));
                }

                var responses = await ESI.MakeEsiRequestsAsync(urls);

                responseOrders = await ESI.ReadResponsesAsArraysAsync<Order>(responses);
                orders.AddRange(responseOrders);

                i++;
            } while (responseOrders.Count() >= 3000);

            return orders;
        }

        /// <summary>
        /// Get a list of orders in a set of regions.
        /// Optionally you can specify a market type.
        /// </summary>
        /// <param name="regionIds">Region ids</param>
        /// <param name="marketTypeIds">Market type ids</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInARegionAsync(IEnumerable<int> regionIds, IEnumerable<int> marketTypeIds)
        {
            int i = 0;
            List<string> urls;

            var regionTypes = await ListTypeIdsReleventToAMarketAsync(regionIds);
            foreach (var key in regionTypes.Keys)
            {
                regionTypes[key] = regionTypes[key].Where(rt => marketTypeIds.Any(mt => rt == mt)).ToList();
            }

            IEnumerable<Order> responseOrders = new List<Order>();
            List<Order> orders = new List<Order>();

            do
            {
                urls = new List<string>();

                foreach (var regionId in regionTypes.Keys)
                {
                    foreach (var typeId in regionTypes[regionId])
                    {
                        urls.Add(ListOrdersInARegion(regionId, typeId, (i * 3) + 1));
                        urls.Add(ListOrdersInARegion(regionId, typeId, (i * 3) + 2));
                        urls.Add(ListOrdersInARegion(regionId, typeId, (i * 3) + 3));
                    }                    
                }

                var responses = await ESI.MakeEsiRequestsAsync(urls);

                int responseIndex = 0;
                foreach (var regionId in regionTypes.Keys)
                {
                    var nextTypes = new List<int>();
                    foreach (var typeId in regionTypes[regionId])
                    {
                        responseOrders = await ESI.ReadResponsesAsArraysAsync<Order>(responses.ToList().GetRange(responseIndex, 3));
                        orders.AddRange(responseOrders);

                        // get types that will still be relevent
                        if (responseOrders.Count() >= 3000)
                        {
                            nextTypes.Add(typeId);
                        }

                        responseIndex += 3;
                    }

                    // update relevent types in region
                    regionTypes[regionId] = nextTypes;
                }

                // update relevent regions
                regionTypes = regionTypes.Where(rt => rt.Value.Count() > 0).ToDictionary(rt => rt.Key, rt => rt.Value);

                i++;
            } while (regionTypes.Count() > 0);

            return orders;
        }

        /// <summary>
        /// Get a list of orders in a constellation
        /// </summary>
        /// <param name="constellationId">Constellation id</param>
        /// <param name="marketTypeId">Market type id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInAConstellationAsync(int constellationId, int? marketTypeId)
        {
            var constellation = await Universe.GetConstellationInformationAsync(constellationId);
            var orders = await ListOrdersInARegionAsync(constellation.RegionID, marketTypeId);

            return orders.Where(o => constellation.Systems.Any(s => s == o.SystemID)).ToList();
        }

        /// <summary>
        /// Get a list of orders in a constellation
        /// </summary>
        /// <param name="constellationId">Constellation id</param>
        /// <param name="marketTypeIds">Market type ids</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInAConstellationAsync(int constellationId, IEnumerable<int> marketTypeIds)
        {
            var constellation = await Universe.GetConstellationInformationAsync(constellationId);
            var orders = await ListOrdersInARegionAsync(constellation.RegionID, marketTypeIds);

            return orders.Where(o => constellation.Systems.Any(s => s == o.SystemID)).ToList();
        }

        /// <summary>
        /// Get a list of orders in a set of constellations
        /// </summary>
        /// <param name="constellationIds">Constellation ids</param>
        /// <param name="marketTypeId">Market type id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInAConstellationAsync(IEnumerable<int> constellationIds, int? marketTypeId)
        {
            var constellations = await Universe.GetConstellationInformationAsync(constellationIds);
            var regionIds = constellations.Select(c => c.RegionID).ToList();

            var systemIds = new List<int>();
            foreach (var constellation in constellations)
            {
                systemIds.AddRange(constellation.Systems);
            }

            var orders = await ListOrdersInARegionAsync(regionIds, marketTypeId);

            return orders.Where(o => systemIds.Any(s => s == o.SystemID)).ToList();
        }

        /// <summary>
        /// Get a list of orders in a set of constellations
        /// </summary>
        /// <param name="constellationIds">Constellation ids</param>
        /// <param name="marketTypeIds">Market type ids</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInAConstellationAsync(IEnumerable<int> constellationIds, IEnumerable<int> marketTypeIds)
        {
            var constellations = await Universe.GetConstellationInformationAsync(constellationIds);
            var regionIds = constellations.Select(c => c.RegionID).ToList();

            var systemIds = new List<int>();
            foreach (var constellation in constellations)
            {
                systemIds.AddRange(constellation.Systems);
            }

            var orders = await ListOrdersInARegionAsync(regionIds, marketTypeIds);

            return orders.Where(o => systemIds.Any(s => s == o.SystemID)).ToList();
        }

        /// <summary>
        /// Get a list of orders in a system
        /// </summary>
        /// <param name="systemId">SolarSystem id</param>
        /// <param name="marketTypeId">Market type id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInASolarSystemAsync(int systemId, int? marketTypeId)
        {
            var system = await Universe.GetSolarSystemInformationAsync(systemId);
            var orders = await ListOrdersInAConstellationAsync(system.ConstellationID, marketTypeId);

            return orders.Where(o => o.SystemID == systemId).ToList();
        }

        /// <summary>
        /// Get a list of orders in a system
        /// </summary>
        /// <param name="systemId">Solar System id</param>
        /// <param name="marketTypeIds">Market type ids</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInASolarSystemAsync(int systemId, IEnumerable<int> marketTypeIds)
        {
            var system = await Universe.GetSolarSystemInformationAsync(systemId);
            var orders = await ListOrdersInAConstellationAsync(system.ConstellationID, marketTypeIds);

            return orders.Where(o => o.LocationID == systemId).ToList();
        }

        /// <summary>
        /// Get a list of orders in a set of systems
        /// </summary>
        /// <param name="systemIds">Solar System ids</param>
        /// <param name="marketTypeId">Market type id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInASolarSystemAsync(IEnumerable<int> systemIds, int? marketTypeId)
        {
            var systems = await Universe.GetSolarSystemInformationAsync(systemIds);
            var constellationIds = systems.Select(s => s.ConstellationID).ToList();
            
            var orders = await ListOrdersInAConstellationAsync(constellationIds, marketTypeId);

            return orders.Where(o => systemIds.Any(s => s == o.SystemID)).ToList();
        }

        /// <summary>
        /// Get a list of orders in a set of systems
        /// </summary>
        /// <param name="systemIds">Solar System ids</param>
        /// <param name="marketTypeIds">Market type ids</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInASolarSystemAsync(IEnumerable<int> systemIds, IEnumerable<int> marketTypeIds)
        {
            var systems = await Universe.GetSolarSystemInformationAsync(systemIds);
            var constellationIds = systems.Select(s => s.ConstellationID).ToList();

            var orders = await ListOrdersInAConstellationAsync(constellationIds, marketTypeIds);

            return orders.Where(o => systemIds.Any(s => s == o.SystemID)).ToList();
        }

        /// <summary>
        /// Get a list of orders in a station
        /// </summary>
        /// <param name="stationId">Station id</param>
        /// <param name="marketTypeId">Market type id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInAStationAsync(int stationId, int? marketTypeId)
        {
            var station = await Universe.GetStationInformationAsync(stationId);
            var orders = await ListOrdersInASolarSystemAsync(station.SystemID, marketTypeId);

            return orders.Where(o => o.LocationID == stationId).ToList();
        }

        /// <summary>
        /// Get a list of orders in a system
        /// </summary>
        /// <param name="stationId">Station id</param>
        /// <param name="marketTypeIds">Market type ids</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInAStationAsync(int stationId, IEnumerable<int> marketTypeIds)
        {
            var station = await Universe.GetStationInformationAsync(stationId);
            var orders = await ListOrdersInASolarSystemAsync(station.SystemID, marketTypeIds);

            return orders.Where(o => o.LocationID == stationId).ToList();
        }

        /// <summary>
        /// Get a list of orders in a set of stations
        /// </summary>
        /// <param name="stationIds">Station ids</param>
        /// <param name="marketTypeId">Market type id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInAStationAsync(IEnumerable<int> stationIds, int? marketTypeId)
        {
            var stations = await Universe.GetStationInformationAsync(stationIds);
            var systemIds = stations.Select(s => s.SystemID).ToList();

            var orders = await ListOrdersInASolarSystemAsync(systemIds, marketTypeId);

            return orders.Where(o => stationIds.Any(s => s == o.LocationID)).ToList();
        }

        /// <summary>
        /// Get a list of orders in a set of stations
        /// </summary>
        /// <param name="stationIds">Station ids</param>
        /// <param name="marketTypeIds">Market type ids</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInAStationAsync(IEnumerable<int> stationIds, IEnumerable<int> marketTypeIds)
        {
            var stations = await Universe.GetStationInformationAsync(stationIds);
            var systemIds = stations.Select(s => s.SystemID).ToList();

            var orders = await ListOrdersInASolarSystemAsync(systemIds, marketTypeIds);

            return orders.Where(o => stationIds.Any(s => s == o.LocationID)).ToList();
        }

        /// <summary>
        /// Get a list of orders in a structure
        /// </summary>
        /// <param name="structureId">Structure id</param>
        /// <param name="marketTypeId">Market type id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInAStructureAsync(long structureId, int? marketTypeId)
        {
            var structure = await Universe.GetStructureInformationAsync(structureId);
            var orders = await ListOrdersInASolarSystemAsync(structure.SolarSystemID, marketTypeId);

            return orders.Where(o => o.LocationID == structureId).ToList();
        }

        /// <summary>
        /// Get a list of orders in a structure
        /// </summary>
        /// <param name="structureId">Structure id</param>
        /// <param name="marketTypeIds">Market type ids</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInAStructureAsync(long structureId, IEnumerable<int> marketTypeIds)
        {
            var structure = await Universe.GetStructureInformationAsync(structureId);
            var orders = await ListOrdersInASolarSystemAsync(structure.SolarSystemID, marketTypeIds);

            return orders.Where(o => o.LocationID == structureId).ToList();
        }

        /// <summary>
        /// Get a list of orders in a set of structures
        /// </summary>
        /// <param name="structureIds">Structure ids</param>
        /// <param name="marketTypeId">Market type id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInAStructureAsync(IEnumerable<long> structureIds, int? marketTypeId)
        {
            var structures = await Universe.GetStructureInformationAsync(structureIds);
            var systemIds = structures.Select(s => s.SolarSystemID).ToList();

            var orders = await ListOrdersInASolarSystemAsync(systemIds, marketTypeId);

            return orders.Where(o => structureIds.Any(s => s == o.LocationID)).ToList();
        }

        /// <summary>
        /// Get a list of orders in a set of structures
        /// </summary>
        /// <param name="structureIds">Structure ids</param>
        /// <param name="marketTypeIds">Market type ids</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersInAStructureAsync(IEnumerable<long> structureIds, IEnumerable<int> marketTypeIds)
        {
            var structures = await Universe.GetStructureInformationAsync(structureIds);
            var systemIds = structures.Select(s => s.SolarSystemID).ToList();

            var orders = await ListOrdersInASolarSystemAsync(systemIds, marketTypeIds);

            return orders.Where(o => structureIds.Any(s => s == o.LocationID)).ToList();
        }

        /// <summary>
        /// Get a list of orders by market type
        /// </summary>
        /// <param name="marketTypeId">Market Type id</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersByTypeAsync(int marketTypeId)
        {
            var regionIds = await Universe.GetRegionsAsync();

            return await ListOrdersInARegionAsync(regionIds, marketTypeId);
        }

        /// <summary>
        /// Get a list of orders by market type
        /// </summary>
        /// <param name="marketTypeIds">Market Type ids</param>
        /// <returns>A collection of <see cref="Order"/></returns>
        public static async Task<IEnumerable<Order>> ListOrdersByTypeAsync(IEnumerable<int> marketTypeIds)
        {
            var regionIds = await Universe.GetRegionsAsync();

            return await ListOrdersInARegionAsync(regionIds, marketTypeIds);
        }

        /// <summary>
        /// Return a list of type IDs that have active orders in the region, for efficient market indexing.
        /// </summary>
        /// <param name="regionId">Region ids</param>
        /// <returns>A collection of market type ids</returns>
        public static async Task<IEnumerable<int>> ListTypeIdsReleventToAMarketAsync(int regionId)
        {
            int i = 0;
            List<string> urls;

            IEnumerable<int> responseIds = new List<int>();
            List<int> typeIds = new List<int>();

            do
            {
                urls = new List<string>();
                urls.Add(ListTypeIdsReleventToAMarket(regionId, (i * 5) + 1));
                urls.Add(ListTypeIdsReleventToAMarket(regionId, (i * 5) + 2));
                urls.Add(ListTypeIdsReleventToAMarket(regionId, (i * 5) + 3));
                urls.Add(ListTypeIdsReleventToAMarket(regionId, (i * 5) + 4));
                urls.Add(ListTypeIdsReleventToAMarket(regionId, (i * 5) + 5));

                var responses = await ESI.MakeEsiRequestsAsync(urls);

                responseIds = await ESI.ReadResponsesAsArraysAsync<int>(responses);
                typeIds.AddRange(responseIds);

                i++;
            } while (responseIds.Count() >= 5000);

            return typeIds;
        }

        /// <summary>
        /// Return a list of type IDs that have active orders in the region, for efficient market indexing.
        /// </summary>
        /// <param name="regionIds">Region ids</param>
        /// <returns>A dictionary of regions and market item ids</returns>
        public static async Task<IDictionary<int, IEnumerable<int>>> ListTypeIdsReleventToAMarketAsync(IEnumerable<int> regionIds)
        {
            int i = 0;
            List<string> urls;

            var tempRegionIds = regionIds;
            IEnumerable<int> responseIds = new List<int>();
            Dictionary<int, IEnumerable<int>> regionTypes = new Dictionary<int, IEnumerable<int>>();
            foreach (var regionId in tempRegionIds)
            {
                regionTypes.Add(regionId, new List<int>());
            }

            do
            {
                urls = new List<string>();

                foreach (var regionId in tempRegionIds)
                {
                    urls.Add(ListTypeIdsReleventToAMarket(regionId, (i * 5) + 1));
                    urls.Add(ListTypeIdsReleventToAMarket(regionId, (i * 5) + 2));
                    urls.Add(ListTypeIdsReleventToAMarket(regionId, (i * 5) + 3));
                    urls.Add(ListTypeIdsReleventToAMarket(regionId, (i * 5) + 4));
                    urls.Add(ListTypeIdsReleventToAMarket(regionId, (i * 5) + 5));
                }

                // get responses
                var responses = await ESI.MakeEsiRequestsAsync(urls);

                // assign response results to regions
                var nextRegions = new List<int>();
                foreach (var regionId in tempRegionIds)
                {
                    int regionIndex = tempRegionIds.ToList().IndexOf(regionId);

                    responseIds = await ESI.ReadResponsesAsArraysAsync<int>(responses.ToList().GetRange(regionIndex * 5, 5));
                    regionTypes[regionId].ToList().AddRange(responseIds);

                    if (responseIds.Count() >= 5000)
                    {
                        nextRegions.Add(regionId);
                    }
                }

                tempRegionIds = nextRegions;
                i++;
            } while (tempRegionIds.Count() > 0);

            return regionTypes;
        }
        #endregion

        #region Item Groups
        /// <summary>
        /// Get a list of item groups
        /// </summary>
        /// <returns>A collection of item group ids</returns>
        public static async Task<IEnumerable<int>> GetItemGroupsAsync()
        {
            var url = GetItemGroups();

            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsArrayAsync<int>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information on an item group
        /// </summary>
        /// <param name="marketGroupId">Market Group Id</param>
        /// <returns>A collection of <see cref="MarketGroup"/></returns>
        public static async Task<MarketGroup> GetItemGroupInformationAsync (int marketGroupId)
        {
            var url = GetItemGroupInformation(marketGroupId);

            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsObjectAsync<MarketGroup>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information on an item group
        /// </summary>
        /// <param name="marketGroupIds">Market Group ids</param>
        /// <returns>A collection of <see cref="MarketGroup"/></returns>
        public static async Task<IEnumerable<MarketGroup>> GetItemGroupInformationAsync (List<int> marketGroupIds)
        {
            var urls = new List<string>();

            foreach (var id in marketGroupIds)
            {
                urls.Add(GetItemGroupInformation(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);

            return await ESI.ReadResponsesAsObjectsAsync<MarketGroup>(responses);
        }
        #endregion

        #region Prices
        /// <summary>
        /// Get a list of prices
        /// </summary>
        /// <returns>A collection of <see cref="MarketPrice"/></returns>
        public static async Task<IEnumerable<MarketPrice>> ListMarketPricesAsync()
        {
            var url = ListMarketPrices();

            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsArrayAsync<MarketPrice>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get a list of historical market statistics for a specified type in a region.
        /// </summary>
        /// <param name="regionId">Region id</param>
        /// <param name="marketTypeId">Market type id</param>
        /// <returns></returns>
        public static async Task<IEnumerable<MarketStatistic>> ListHistoricalMarketStatisticsInARegionAsync(int regionId, int marketTypeId)
        {
            var url = ListHistoricalMarketStatisticsInARegion(regionId, marketTypeId);

            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsArrayAsync<MarketStatistic>(responses.ElementAt(0));
        }
        #endregion
        #endregion
    }
}
