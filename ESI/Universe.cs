using ESI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESI
{
    /// <summary>
    /// Universe ESI urls and queries
    /// </summary>
    public static class Universe
    {
        #region URLs
        /// <summary>
        /// Get all character ancestries
        /// </summary>
        /// <returns>Url for retrieving character ancestries</returns>
        public static string GetAncestries()
        {
            return "https://esi.evetech.net/v1/universe/ancestries/?datasource=tranquility&language=en-us";
        }

        /// <summary>
        /// Get information on an asteroid belt
        /// </summary>
        /// <param name="asteroidBeltId">Asteroid belt id</param>
        /// <returns>Url for retrieving information for the given asteroid belt</returns>
        public static string GetAsteroidBeltInformation(int asteroidBeltId)
        {
            return $"https://esi.evetech.net/v1/universe/asteroid_belts/{asteroidBeltId}/?datasource=tranquility";
        }

        /// <summary>
        /// Get a list of bloodlines
        /// </summary>
        /// <returns>Url for retrieving character bloodlines</returns>
        public static string GetBloodlines()
        {
            return "https://esi.evetech.net/v1/universe/bloodlines/?datasource=tranquility&language=en-us";
        }

        /// <summary>
        /// Get a list of item categories
        /// </summary>
        /// <returns>Url for retrieving list of item category ids</returns>
        public static string GetItemCategories()
        {
            return "https://esi.evetech.net/v1/universe/categories/?datasource=tranquility";
        }

        /// <summary>
        /// Get information of an item category
        /// </summary>
        /// <param name="categoryId">Category id</param>
        /// <returns>Url for retrieving information for the given category</returns>
        public static string GetItemCategoryInformation(int categoryId)
        {
            return $"https://esi.evetech.net/v1/universe/categories/{categoryId}/?datasource=tranquility&language=en-us";
        }

        /// <summary>
        /// Get a list of constellations
        /// </summary>
        /// <returns>Url for retrieving list of constellation ids</returns>
        public static string GetConstellations()
        {
            return "https://esi.evetech.net/v1/universe/constellations/?datasource=tranquility";
        }

        /// <summary>
        /// Get information on a constellation
        /// </summary>
        /// <param name="constellationId">Constellation id</param>
        /// <returns>Url for retrieving information for the given constellation</returns>
        public static string GetConstellationInformation(int constellationId)
        {
            return $"https://esi.evetech.net/v1/universe/constellations/{constellationId}/?datasource=tranquility&language=en-us";
        }

        /// <summary>
        /// Get a list of factions
        /// </summary>
        /// <returns>Url for retrieving a list of factions</returns>
        public static string GetFactions()
        {
            return "https://esi.evetech.net/v2/universe/factions/?datasource=tranquility&language=en-us";
        }

        /// <summary>
        /// Get a list of graphics
        /// </summary>
        /// <returns>Url for retrieving a list of graphic ids</returns>
        public static string GetGraphics()
        {
            return "https://esi.evetech.net/v1/universe/graphics/?datasource=tranquility";
        }

        /// <summary>
        /// Get information on a grapic
        /// </summary>
        /// <param name="graphicId">Graphic id</param>
        /// <returns>Url for retrieving information for the given graphic</returns>
        public static string GetGraphicInformation(int graphicId)
        {
            return $"https://esi.evetech.net/v1/universe/graphics/{graphicId}/?datasource=tranquility";
        }

        /// <summary>
        /// Get a list of item groups
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>Url for retrieving a list of group ids</returns>
        public static string GetItemGroups(int page = 1)
        {
            return $"https://esi.evetech.net/v1/universe/groups/?datasource=tranquility&page={page}";
        }

        /// <summary>
        /// Get information on an item group
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <returns>Url for retrieving information for the given group</returns>
        public static string GetItemGroupInformation(int groupId)
        {
            return $"https://esi.evetech.net/v1/universe/groups/{groupId}/?datasource=tranquility&language=en-us";
        }

        /// <summary>
        /// Get information on a moon
        /// </summary>
        /// <param name="moonId">Moon id</param>
        /// <returns>Url for retrieving information for the given moon</returns>
        public static string GetMoonInformation(int moonId)
        {
            return $"https://esi.evetech.net/v1/universe/moons/{moonId}/?datasource=tranquility";
        }

        /// <summary>
        /// Get information on a planet
        /// </summary>
        /// <param name="planetId">Planet id</param>
        /// <returns>Url for retrieving information for the given planet</returns>
        public static string GetPlanetInformation(int planetId)
        {
            return $"https://esi.evetech.net/v1/universe/planets/{planetId}/?datasource=tranquility";
        }

        /// <summary>
        /// Get a list of character races
        /// </summary>
        /// <returns>Url for retrieving character races</returns>
        public static string GetCharacterRaces()
        {
            return "https://esi.evetech.net/v1/universe/races/?datasource=tranquility&language=en-us";
        }

        /// <summary>
        /// Get a list of regions
        /// </summary>
        /// <returns>Url for retrieving a list of region ids</returns>
        public static string GetRegions()
        {
            return "https://esi.evetech.net/v1/universe/regions/?datasource=tranquility";
        }

        /// <summary>
        /// Get information on a region
        /// </summary>
        /// <param name="regionId">Region id</param>
        /// <returns>Url for retrieving information for a given region</returns>
        public static string GetRegionInformation(int regionId)
        {
            return $"https://esi.evetech.net/v1/universe/regions/{regionId}/?datasource=tranquility&language=en-us";
        }

        /// <summary>
        /// Get information on a stargate
        /// </summary>
        /// <param name="stargateId">Stargate id</param>
        /// <returns>Url for retrieving information for a given stargate</returns>
        public static string GetStargateInformation(int stargateId)
        {
            return $"https://esi.evetech.net/v1/universe/stargates/{stargateId}/?datasource=tranquility";
        }

        /// <summary>
        /// Get information on a star
        /// </summary>
        /// <param name="starId">Star id</param>
        /// <returns>Url for retrieving information for a given star</returns>
        public static string GetStarInformation(int starId)
        {
            return $"https://esi.evetech.net/v1/universe/stars/{starId}/?datasource=tranquility";
        }

        /// <summary>
        /// Get information on a station
        /// </summary>
        /// <param name="stationId">Station id</param>
        /// <returns>Url for retrieving information for a given station</returns>
        public static string GetStationInformation(int stationId)
        {
            return $"https://esi.evetech.net/v2/universe/stations/{stationId}/?datasource=tranquility";
        }

        /// <summary>
        /// List all public structures
        /// </summary>
        /// <returns>Url for retrieving a list of all public structure ids</returns>
        public static string ListAllPublicStructures()
        {
            return "https://esi.evetech.net/v1/universe/structures/?datasource=tranquility";
        }

        /// <summary>
        /// Returns information on requested structure if you are on the ACL. 
        /// Otherwise, returns "Forbidden" for all inputs.
        /// </summary>
        /// <param name="structureId">Structure id</param>
        /// <returns>Url for retrieving information for a given structure</returns>
        public static string GetStructureInformation(long structureId)
        {
            return $"https://esi.evetech.net/v2/universe/structures/{structureId}/?datasource=tranquility";
        }

        /// <summary>
        /// Get the number of jumps in solar systems within the last hour ending at the timestamp of the Last-Modified header, excluding wormhole space. 
        /// Only systems with jumps will be listed
        /// </summary>
        /// <returns>Url for retrieving information about jumps to/from solar systems</returns>
        public static string GetSystemJumps()
        {
            return "https://esi.evetech.net/v1/universe/system_jumps/?datasource=tranquility";
        }

        /// <summary>
        /// Get the number of ship, pod and NPC kills per solar system within the last hour ending at the timestamp of the Last-Modified header, excluding wormhole space. 
        /// Only systems with kills will be listed
        /// </summary>
        /// <returns>Url for retrieving information about kills in solar systems</returns>
        public static string GetSystemKills()
        {
            return "https://esi.evetech.net/v2/universe/system_kills/?datasource=tranquility";
        }

        /// <summary>
        /// Get a list of solar systems.
        /// </summary>
        /// <returns>Url for retrieving a list of solar system ids</returns>
        public static string GetSolarSystems()
        {
            return "https://esi.evetech.net/v1/universe/systems/?datasource=tranquility";
        }

        /// <summary>
        /// Get information on a solar system.
        /// </summary>
        /// <param name="systemId">System id</param>
        /// <returns>Url for retrieving information for a solar system</returns>
        public static string GetSolarSystemInformation(int systemId)
        {
            return $"https://esi.evetech.net/v4/universe/systems/{systemId}/?datasource=tranquility&language=en-us";
        }

        /// <summary>
        /// Get a list of type ids
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>Url for retrieving a list of type ids</returns>
        public static string GetTypes(int page = 1)
        {
            return $"https://esi.evetech.net/v1/universe/types/?datasource=tranquility&page={page}";
        }

        /// <summary>
        /// Get information on a type
        /// </summary>
        /// <param name="typeId">Type id</param>
        /// <returns>Url for retrieving information for the given type</returns>
        public static string GetTypeInformation(int typeId)
        {
            return $"https://esi.evetech.net/v3/universe/types/{typeId}/?datasource=tranquility&language=en-us";
        }
        #endregion

        #region Data Queries
        #region Race/Bloodline/Ancestry
        #region Race
        /// <summary>
        /// Get a list of races
        /// </summary>
        /// <returns>A collection of <see cref="Race"/></returns>
        public static async Task<IEnumerable<Race>> GetCharacterRacesAsync()
        {
            string url = GetCharacterRaces();
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsArrayAsync<Race>(responses.ElementAt(0));
        }
        #endregion

        #region Bloodline
        /// <summary>
        /// Get a list of bloodlines
        /// </summary>
        /// <returns>A collection of <see cref="Bloodline"/></returns>
        public static async Task<IEnumerable<Bloodline>> GetBloodlinesAsync()
        {
            string url = GetBloodlines();
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsArrayAsync<Bloodline>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get a list of bloodlines for a given race
        /// </summary>
        /// <param name="raceId">Race id</param>
        /// <returns>A collection of <see cref="Bloodline"/></returns>
        public static async Task<IEnumerable<Bloodline>> GetBloodlinesByRaceAsync(int raceId)
        {
            var bloodlines = await GetBloodlinesAsync();

            return bloodlines.Where(b => b.RaceID == raceId);
        }

        /// <summary>
        /// Get a list of bloodlines for a given set of races
        /// </summary>
        /// <param name="raceIds">Race ids</param>
        /// <returns>A collection of <see cref="Bloodline"/></returns>
        public static async Task<IEnumerable<Bloodline>> GetBloodlinesByRaceAsync(IEnumerable<int> raceIds)
        {
            var bloodlines = await GetBloodlinesAsync();

            return bloodlines.Where(b => raceIds.Any(r => r == b.RaceID));
        }
        #endregion

        #region Ancestry
        /// <summary>
        /// Get all character ancestries
        /// </summary>
        /// <returns>A collection of <see cref="Ancestry"/></returns>
        public static async Task<IEnumerable<Ancestry>> GetAncestriesAsync()
        {
            string url = GetAncestries();
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsArrayAsync<Ancestry>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get a list of ancestries for a given bloodline
        /// </summary>
        /// <param name="bloodlineId">Bloodline id</param>
        /// <returns>A collection of <see cref="Ancestry"/></returns>
        public static async Task<IEnumerable<Ancestry>> GetAncestriesByBloodlineAsync(int bloodlineId)
        {
            var ancestries = await GetAncestriesAsync();

            return ancestries.Where(a => a.BloodlineID == bloodlineId);
        }

        /// <summary>
        /// Get a list of ancestries for a given set of bloodlines
        /// </summary>
        /// <param name="bloodlineIds">Bloodline ids</param>
        /// <returns>A collection of <see cref="Ancestry"/></returns>
        public static async Task<IEnumerable<Ancestry>> GetAncestriesByBloodlineAsync(IEnumerable<int> bloodlineIds)
        {
            var ancestries = await GetAncestriesAsync();

            return ancestries.Where(a => bloodlineIds.Any(b => b == a.BloodlineID));
        }

        /// <summary>
        /// Get a list of ancestries for a given race
        /// </summary>
        /// <param name="raceId">Race id</param>
        /// <returns>A collection of <see cref="Ancestry"/></returns>
        public static async Task<IEnumerable<Ancestry>> GetAncestriesByRaceAsync(int raceId)
        {
            var ancestries = await GetAncestriesAsync();
            var bloodlines = await GetBloodlinesByRaceAsync(raceId);

            return ancestries.Where(a => bloodlines.Any(b => b.ID == a.BloodlineID));
        }

        /// <summary>
        /// Get a list of ancestries for a given set of races
        /// </summary>
        /// <param name="raceIds">Race ids</param>
        /// <returns>A collection of <see cref="Ancestry"/></returns>
        public static async Task<IEnumerable<Ancestry>> GetAncestriesByRaceAsync(IEnumerable<int> raceIds)
        {
            var ancestries = await GetAncestriesAsync();
            var bloodlines = await GetBloodlinesByRaceAsync(raceIds);

            return ancestries.Where(a => bloodlines.Any(b => b.ID == a.BloodlineID));
        }
        #endregion
        #endregion

        #region Category/Group/Item
        #region Category
        /// <summary>
        /// Get a list of item categories
        /// </summary>
        /// <returns>A collection of category ids</returns>
        public static async Task<IEnumerable<int>> GetItemCategoriesAsync()
        {
            string url = GetItemCategories();
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsArrayAsync<int>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information of an item category
        /// </summary>
        /// <param name="categoryId">Category id</param>
        /// <returns>A <see cref="Category"/></returns>
        public static async Task<Category> GetItemCategoryInformationAsync(int categoryId)
        {
            string url = GetItemCategoryInformation(categoryId);
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsObjectAsync<Category>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a set of categories
        /// </summary>
        /// <param name="categoryIds">Category id</param>
        /// <returns>A collection of <see cref="Category"/></returns>
        public static async Task<IEnumerable<Category>> GetItemCategoryInformationAsync(IEnumerable<int> categoryIds)
        {
            List<string> urls = new List<string>();

            foreach (var id in categoryIds)
            {
                urls.Add(GetItemCategoryInformation(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);

            return await ESI.ReadResponsesAsObjectsAsync<Category>(responses);
        }

        /// <summary>
        /// Get information for all item categories
        /// </summary>
        /// <returns>A collection of <see cref="Category"/></returns>
        public static async Task<IEnumerable<Category>> GetItemCategoryInformationAsync()
        {
            var categoryIds = await GetItemCategoriesAsync();

            return await GetItemCategoryInformationAsync(categoryIds);
        }
        #endregion

        #region Group
        /// <summary>
        /// Get a list of all item group ids
        /// </summary>
        /// <returns>A collection of item group ids</returns>
        public static async Task<IEnumerable<int>> GetItemGroupsAsync()
        {
            int i = 1;
            List<int> groupIds = new List<int>();
            IEnumerable<int> responseIds = new List<int>();
            do
            {
                string url = GetItemGroups(i);
                var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

                responseIds = await ESI.ReadResponseAsArrayAsync<int>(responses.ElementAt(0));
                groupIds.AddRange(responseIds);
            } while (responseIds.Count() >= 1000);

            return groupIds;
        }

        /// <summary>
        /// Get information about an item group
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <returns>A <see cref="Group"/></returns>
        public static async Task<Group> GetItemGroupInformationAsync(int groupId)
        {
            string url = GetItemGroupInformation(groupId);
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsObjectAsync<Group>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a set of item groups
        /// </summary>
        /// <param name="groupIds">Collection of group ids</param>
        /// <returns>A collection of <see cref="Group"/></returns>
        public static async Task<IEnumerable<Group>> GetItemGroupInformationAsync(IEnumerable<int> groupIds)
        {
            List<string> urls = new List<string>();

            foreach (var id in groupIds)
            {
                urls.Add(GetItemGroupInformation(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);

            return await ESI.ReadResponsesAsObjectsAsync<Group>(responses);
        }

        /// <summary>
        /// Get information for all item groups
        /// </summary>
        /// <returns>A collection of <see cref="Group"/></returns>
        public static async Task<IEnumerable<Group>> GetItemGroupInformationAsync()
        {
            var groupIds = await GetItemGroupsAsync();

            return await GetItemGroupInformationAsync(groupIds);
        }

        /// <summary>
        /// Get information for all item groups in a category
        /// </summary>
        /// <param name="categoryId">Category id</param>
        /// <returns>A collection of <see cref="Group"/></returns>
        public static async Task<IEnumerable<Group>> GetItemGroupInformationByCategoryAsync(int categoryId)
        {
            // Get category information
            var category = await GetItemCategoryInformationAsync(categoryId);

            return await GetItemGroupInformationAsync(category.Groups);
        }

        /// <summary>
        /// Get information for all item groups in a set of categories
        /// </summary>
        /// <param name="categoryIds">Category ids</param>
        /// <returns>A collection of <see cref="Group"/></returns>
        public static async Task<IEnumerable<Group>> GetItemGroupInformationByCategoryAsync(IEnumerable<int> categoryIds)
        {
            // Get category information
            var categories = await GetItemCategoryInformationAsync(categoryIds);

            List<int> groupIds = new List<int>();

            foreach (var category in categories)
            {
                groupIds.AddRange(category.Groups);
            }

            return await GetItemGroupInformationAsync(groupIds);
        }
        #endregion

        #region Item
        /// <summary>
        /// Gets a list of all item ids
        /// </summary>
        /// <returns>A collection of item ids</returns>
        public static async Task<IEnumerable<int>> GetTypesAsync()
        {
            // Get all categories
            var categoryIds = await GetItemCategoriesAsync();

            // Get all groups
            var groups = await GetItemGroupInformationByCategoryAsync(categoryIds);

            // Get all item ids from groups
            List<int> itemIds = new List<int>();
            foreach (var group in groups)
            {
                itemIds.AddRange(group.Types);
            }

            return itemIds;
        }

        /// <summary>
        /// Get information for an item
        /// </summary>
        /// <param name="typeId">Item id</param>
        /// <returns>An <see cref="Item"/></returns>
        public static async Task<Item> GetTypeInformationAsync(int typeId)
        {
            string url = GetTypeInformation(typeId);
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsObjectAsync<Item>(responses.ElementAt(0));
        }

        /// <summary>
        /// Gets information for a set of items
        /// </summary>
        /// <param name="typeIds">Item ids</param>
        /// <returns>A collection of <see cref="Item"/></returns>
        public static async Task<IEnumerable<Item>> GetTypeInformationAsync(IEnumerable<int> typeIds)
        {
            List<string> urls = new List<string>();

            foreach (var id in typeIds)
            {
                urls.Add(GetTypeInformation(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);

            return await ESI.ReadResponsesAsObjectsAsync<Item>(responses);
        }

        /// <summary>
        /// Gets information for all items
        /// </summary>
        /// <returns>A collection of <see cref="Item"/></returns>
        public static async Task<IEnumerable<Item>> GetTypeInformationAsync()
        {
            var itemIds = await GetTypesAsync();

            return await GetTypeInformationAsync(itemIds);
        }

        /// <summary>
        /// Get information for all items in a group
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <returns>A collection of <see cref="Item"/></returns>
        public static async Task<IEnumerable<Item>> GetTypeInformationByGroupAsync(int groupId)
        {
            // Get group information
            var group = await GetItemGroupInformationAsync(groupId);

            return await GetTypeInformationAsync(group.Types);
        }

        /// <summary>
        /// Get information for all items in a set of groups
        /// </summary>
        /// <param name="groupIds">Group ids</param>
        /// <returns>A collection of <see cref="Item"/></returns>
        public static async Task<IEnumerable<Item>> GetTypeInformationByGroupAsync(IEnumerable<int> groupIds)
        {
            // Get group information
            var groups = await GetItemGroupInformationAsync(groupIds);

            List<int> itemIds = new List<int>();

            foreach (var group in groups)
            {
                itemIds.AddRange(group.Types);
            }

            return await GetTypeInformationAsync(itemIds);
        }

        /// <summary>
        /// Get information for all items in a category
        /// </summary>
        /// <param name="categoryId">Category id</param>
        /// <returns>A collection of <see cref="Item"/></returns>
        public static async Task<IEnumerable<Item>> GetTypeInformationByCategoryAsync(int categoryId)
        {
            // Get group information
            var groups = await GetItemGroupInformationByCategoryAsync(categoryId);

            List<int> itemIds = new List<int>();

            foreach (var group in groups)
            {
                itemIds.AddRange(group.Types);
            }

            return await GetTypeInformationAsync(itemIds);
        }

        /// <summary>
        /// Get information for all items in a set of categories
        /// </summary>
        /// <param name="categoryIds">Category ids</param>
        /// <returns>A collection of <see cref="Item"/></returns>
        public static async Task<IEnumerable<Item>> GetTypeInformationByCategoryAsync(IEnumerable<int> categoryIds)
        {
            // Get group information
            var groups = await GetItemGroupInformationByCategoryAsync(categoryIds);

            List<int> itemIds = new List<int>();

            foreach (var group in groups)
            {
                itemIds.AddRange(group.Types);
            }

            return await GetTypeInformationAsync(itemIds);
        }
        #endregion
        #endregion

        #region Region/Constellation/System/Star/Planet/Moon
        #region Region
        /// <summary>
        /// Get a list of region ids
        /// </summary>
        /// <returns>A collection of region ids</returns>
        public static async Task<IEnumerable<int>> GetRegionsAsync()
        {
            string url = GetRegions();
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsArrayAsync<int>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a region
        /// </summary>
        /// <returns>A <see cref="Region"/></returns>
        public static async Task<Region> GetRegionInformationAsync(int regionId)
        {
            string url = GetRegionInformation(regionId);
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsObjectAsync<Region>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a set of regions
        /// </summary>
        /// <param name="regionIds">Region ids</param>
        /// <returns>A collection of <see cref="Region"/></returns>
        public static async Task<IEnumerable<Region>> GetRegionInformationAsync(IEnumerable<int> regionIds)
        {
            List<string> urls = new List<string>();

            foreach (var id in regionIds)
            {
                urls.Add(GetRegionInformation(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);

            return await ESI.ReadResponsesAsObjectsAsync<Region>(responses);
        }

        /// <summary>
        /// Get information for all regions
        /// </summary>
        /// <returns>A collection of <see cref="Region"/></returns>
        public static async Task<IEnumerable<Region>> GetRegionInformationAsync()
        {
            var regionIds = await GetRegionsAsync();

            return await GetRegionInformationAsync(regionIds);
        }
        #endregion

        #region Constellation
        /// <summary>
        /// Get a list of constellation ids
        /// </summary>
        /// <returns>A collection of constellation ids</returns>
        public static async Task<IEnumerable<int>> GetConstellationsAsync()
        {
            string url = GetConstellations();
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsArrayAsync<int>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a constellation
        /// </summary>
        /// <param name="constellationId">Constellation id</param>
        /// <returns>A <see cref="Constellation"/></returns>
        public static async Task<Constellation> GetConstellationInformationAsync(int constellationId)
        {
            string url = GetConstellationInformation(constellationId);
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsObjectAsync<Constellation>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a set of constellations
        /// </summary>
        /// <param name="constellationIds">Constellation ids</param>
        /// <returns>A collection of <see cref="Constellation"/></returns>
        public static async Task<IEnumerable<Constellation>> GetConstellationInformationAsync(IEnumerable<int> constellationIds)
        {
            List<string> urls = new List<string>();

            foreach (var id in constellationIds)
            {
                urls.Add(GetConstellationInformation(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);

            return await ESI.ReadResponsesAsObjectsAsync<Constellation>(responses);
        }

        /// <summary>
        /// Get information for all constellations
        /// </summary>
        /// <returns>A collection of <see cref="Constellation"/></returns>
        public static async Task<IEnumerable<Constellation>> GetConstellationInformationAsync()
        {
            var regionIds = await GetConstellationsAsync();

            return await GetConstellationInformationAsync(regionIds);
        }

        /// <summary>
        /// Get information for constellations in a given region
        /// </summary>
        /// <param name="regionId">Region id</param>
        /// <returns>A collection of <see cref="Constellation"/></returns>
        public static async Task<IEnumerable<Constellation>> GetConstellationInformationByRegionAsync(int regionId)
        {
            var region = await GetRegionInformationAsync(regionId);

            return await GetConstellationInformationAsync(region.Constellations);
        }

        /// <summary>
        /// Get information for constellations in a given set of region
        /// </summary>
        /// <param name="regionIds">Region ids</param>
        /// <returns>A collection of <see cref="Constellation"/></returns>
        public static async Task<IEnumerable<Constellation>> GetConstellationInformationByRegionAsync(IEnumerable<int> regionIds)
        {
            var constellationIds = new List<int>();
            var regions = await GetRegionInformationAsync(regionIds);

            foreach (var region in regions)
            {
                constellationIds.AddRange(region.Constellations);
            }

            return await GetConstellationInformationAsync(constellationIds);
        }
        #endregion

        #region System
        /// <summary>
        /// Get a list of solar system ids
        /// </summary>
        /// <returns>A collection of solar system ids</returns>
        public static async Task<IEnumerable<int>> GetSolarSystemsAsync()
        {
            string url = GetSolarSystems();
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsArrayAsync<int>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a solar system
        /// </summary>
        /// <param name="systemId">Solar System id</param>
        /// <returns>A <see cref="SolarSystem"/></returns>
        public static async Task<SolarSystem> GetSolarSystemInformationAsync(int systemId)
        {
            string url = GetSolarSystemInformation(systemId);
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsObjectAsync<SolarSystem>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a set of solar systems
        /// </summary>
        /// <param name="systemIds">Solar System ids</param>
        /// <returns>A collection of <see cref="SolarSystem"/></returns>
        public static async Task<IEnumerable<SolarSystem>> GetSolarSystemInformationAsync(IEnumerable<int> systemIds)
        {
            List<string> urls = new List<string>();

            foreach (var id in systemIds)
            {
                urls.Add(GetSolarSystemInformation(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);

            return await ESI.ReadResponsesAsObjectsAsync<SolarSystem>(responses);
        }

        /// <summary>
        /// Get information for all solar systems
        /// </summary>
        /// <returns>A collection of <see cref="SolarSystem"/></returns>
        public static async Task<IEnumerable<SolarSystem>> GetSolarSystemInformationAsync()
        {
            var systemIds = await GetSolarSystemsAsync();

            return await GetSolarSystemInformationAsync(systemIds);
        }

        /// <summary>
        /// Get information for solar systems in a given constellation
        /// </summary>
        /// <param name="constellationId">Constellation id</param>
        /// <returns>A collection of <see cref="SolarSystem"/></returns>
        public static async Task<IEnumerable<SolarSystem>> GetSolarSystemInformationByConstellationAsync(int constellationId)
        {
            var constellation = await GetConstellationInformationAsync(constellationId);

            return await GetSolarSystemInformationAsync(constellation.Systems);
        }

        /// <summary>
        /// Get information for solar systems in a given set of constellations
        /// </summary>
        /// <param name="constellationIds">Constellation ids</param>
        /// <returns>A collection of <see cref="SolarSystem"/></returns>
        public static async Task<IEnumerable<SolarSystem>> GetSolarSystemInformationByConstellationAsync(IEnumerable<int> constellationIds)
        {
            List<int> systemIds = new List<int>();
            var constellations = await GetConstellationInformationAsync(constellationIds);

            foreach (var constellation in constellations)
            {
                systemIds.AddRange(constellation.Systems);
            }

            return await GetSolarSystemInformationAsync(systemIds);
        }

        /// <summary>
        /// Get information for solar systems in a given region
        /// </summary>
        /// <param name="regionId">Region id</param>
        /// <returns>A collection of <see cref="SolarSystem"/></returns>
        public static async Task<IEnumerable<SolarSystem>> GetSolarSystemInformationByRegionAsync(int regionId)
        {
            var region = await GetRegionInformationAsync(regionId);

            return await GetSolarSystemInformationByConstellationAsync(region.Constellations);
        }

        /// <summary>
        /// Get information for solar systems in a given set of regions
        /// </summary>
        /// <param name="regionIds">Region ids</param>
        /// <returns>A collection of <see cref="SolarSystem"/></returns>
        public static async Task<IEnumerable<SolarSystem>> GetSolarSystemInformationByRegionAsync(IEnumerable<int> regionIds)
        {
            List<int> constellationIds = new List<int>();
            var regions = await GetRegionInformationAsync(regionIds);

            foreach (var region in regions)
            {
                constellationIds.AddRange(region.Constellations);
            }

            return await GetSolarSystemInformationByConstellationAsync(constellationIds);
        }
        #endregion

        #region Star
        /// <summary>
        /// Get information for a star
        /// </summary>
        /// <param name="starId">Star id</param>
        /// <returns>A <see cref="Star"/></returns>
        public static async Task<Star> GetStarInformationAsync(int starId)
        {
            string url = GetStarInformation(starId);
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsObjectAsync<Star>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a set of stars
        /// </summary>
        /// <param name="starIds">Star ids</param>
        /// <returns>A collection of <see cref="Star"/></returns>
        public static async Task<IEnumerable<Star>> GetStarInformationAsync(IEnumerable<int> starIds)
        {
            var urls = new List<string>();
            foreach (var id in starIds)
            {
                urls.Add(GetStarInformation(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);

            return await ESI.ReadResponsesAsObjectsAsync<Star>(responses);
        }

        /// <summary>
        /// Get information for a star in a given solar system
        /// </summary>
        /// <param name="systemId">Solar System id</param>
        /// <returns>A <see cref="Star"/></returns>
        public static async Task<Star> GetStarInformationBySolarSystemAsync(int systemId)
        {
            var system = await GetSolarSystemInformationAsync(systemId);

            return await GetStarInformationAsync(system.StarID);
        }

        /// <summary>
        /// Get information for stars in a given set of solar systems
        /// </summary>
        /// <param name="systemIds">Solar System ids</param>
        /// <returns>A collection of <see cref="Star"/></returns>
        public static async Task<IEnumerable<Star>> GetStarInformationBySolarSystemAsync(IEnumerable<int> systemIds)
        {
            var starIds = new List<int>();
            var systems = await GetSolarSystemInformationAsync(systemIds);

            foreach (var system in systems)
            {
                starIds.Add(system.StarID);
            }

            return await GetStarInformationAsync(starIds);
        }

        /// <summary>
        /// Get information for stars in a given constellation
        /// </summary>
        /// <param name="constellationId">Constellation id</param>
        /// <returns>A collection of <see cref="Star"/></returns>
        public static async Task<IEnumerable<Star>> GetStarInformationByConstellationAsync(int constellationId)
        {
            var constellation = await GetConstellationInformationAsync(constellationId);

            return await GetStarInformationBySolarSystemAsync(constellation.Systems);
        }

        /// <summary>
        /// Get information for stars in a given set of constellations
        /// </summary>
        /// <param name="constellationIds">Constellation ids</param>
        /// <returns>A collection of <see cref="Star"/></returns>
        public static async Task<IEnumerable<Star>> GetStarInformationByConstellationAsync(IEnumerable<int> constellationIds)
        {
            var systemIds = new List<int>();
            var constellations = await GetConstellationInformationAsync(constellationIds);

            foreach (var constellation in constellations)
            {
                systemIds.AddRange(constellation.Systems);
            }

            return await GetStarInformationBySolarSystemAsync(systemIds);
        }

        /// <summary>
        /// Get information for stars in a given region
        /// </summary>
        /// <param name="regionId">Region id</param>
        /// <returns>A collection of <see cref="Star"/></returns>
        public static async Task<IEnumerable<Star>> GetStarInformationByRegionAsync(int regionId)
        {
            var region = await GetRegionInformationAsync(regionId);

            return await GetStarInformationByConstellationAsync(region.Constellations);
        }

        /// <summary>
        /// Get information for stars in a given set of regions
        /// </summary>
        /// <param name="regionIds">Region ids</param>
        /// <returns>A collection of <see cref="Star"/></returns>
        public static async Task<IEnumerable<Star>> GetStarInformationByRegionAsync(IEnumerable<int> regionIds)
        {
            var constellationIds = new List<int>();
            var regions = await GetRegionInformationAsync(regionIds);

            foreach (var region in regions)
            {
                constellationIds.AddRange(region.Constellations);
            }

            return await GetStarInformationByConstellationAsync(constellationIds);
        }
        #endregion

        #region Planet
        /// <summary>
        /// Get information for a planet
        /// </summary>
        /// <param name="planetId">Planet id</param>
        /// <returns>A <see cref="Planet"/></returns>
        public static async Task<Planet> GetPlanetInformationAsync(int planetId)
        {
            string url = GetPlanetInformation(planetId);
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });
            var planet = await ESI.ReadResponseAsObjectAsync<Planet>(responses.ElementAt(0));
            var system = await GetSolarSystemInformationAsync(planet.SystemID);

            planet.Moons = system.Planets.First(p => p.ID == planetId).Moons.ToList();

            return planet;
        }

        /// <summary>
        /// Get information for a set of planets
        /// </summary>
        /// <param name="planetIds">Planet ids</param>
        /// <returns>A collection of <see cref="Planet"/></returns>
        public static async Task<IEnumerable<Planet>> GetPlanetInformationAsync(IEnumerable<int> planetIds)
        {
            var urls = new List<string>();
            foreach (var id in planetIds)
            {
                urls.Add(GetPlanetInformation(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);
            var planets = await ESI.ReadResponsesAsObjectsAsync<Planet>(responses);

            // Get systems
            var systemIds = planets.Select(p => p.SystemID).Distinct().ToList();
            var systems = await GetSolarSystemInformationAsync(systemIds);

            // Get planet moons
            foreach (var planet in planets)
            {
                var system = systems.First(s => s.Planets.Any(p => p.ID == planet.ID));
                planet.Moons = system.Planets.First(p => p.ID == planet.ID).Moons;
            }

            return planets;
        }

        /// <summary>
        /// Get information for planets in a given solar system
        /// </summary>
        /// <param name="systemId">Solar System id</param>
        /// <returns>A <see cref="Planet"/></returns>
        public static async Task<IEnumerable<Planet>> GetPlanetInformationBySolarSystemAsync(int systemId)
        {
            var planetIds = new List<int>();
            var system = await GetSolarSystemInformationAsync(systemId);

            foreach (var planet in system.Planets)
            {
                planetIds.Add(planet.ID);
            }

            return await GetPlanetInformationAsync(planetIds);
        }

        /// <summary>
        /// Get information for planets in a given set of solar systems
        /// </summary>
        /// <param name="systemIds">Solar System ids</param>
        /// <returns>A collection of <see cref="Planet"/></returns>
        public static async Task<IEnumerable<Planet>> GetPlanetInformationBySolarSystemAsync(IEnumerable<int> systemIds)
        {
            var planetIds = new List<int>();
            var systems = await GetSolarSystemInformationAsync(systemIds);

            foreach (var system in systems)
            {
                foreach (var planet in system.Planets)
                {
                    planetIds.Add(planet.ID);
                }
            }

            return await GetPlanetInformationAsync(planetIds);
        }

        /// <summary>
        /// Get information for planets in a given constellation
        /// </summary>
        /// <param name="constellationId">Constellation id</param>
        /// <returns>A collection of <see cref="Planet"/></returns>
        public static async Task<IEnumerable<Planet>> GetPlanetInformationByConstellationAsync(int constellationId)
        {
            var constellation = await GetConstellationInformationAsync(constellationId);

            return await GetPlanetInformationBySolarSystemAsync(constellation.Systems);
        }

        /// <summary>
        /// Get information for planets in a given set of constellations
        /// </summary>
        /// <param name="constellationIds">Constellation ids</param>
        /// <returns>A collection of <see cref="Planet"/></returns>
        public static async Task<IEnumerable<Planet>> GetPlanetInformationByConstellationAsync(IEnumerable<int> constellationIds)
        {
            var systemIds = new List<int>();
            var constellations = await GetConstellationInformationAsync(constellationIds);

            foreach (var constellation in constellations)
            {
                systemIds.AddRange(constellation.Systems);
            }

            return await GetPlanetInformationBySolarSystemAsync(systemIds);
        }

        /// <summary>
        /// Get information for planets in a given region
        /// </summary>
        /// <param name="regionId">Region id</param>
        /// <returns>A collection of <see cref="Planet"/></returns>
        public static async Task<IEnumerable<Planet>> GetPlanetInformationByRegionAsync(int regionId)
        {
            var region = await GetRegionInformationAsync(regionId);

            return await GetPlanetInformationByConstellationAsync(region.Constellations);
        }

        /// <summary>
        /// Get information for planets in a given set of regions
        /// </summary>
        /// <param name="regionIds">Region ids</param>
        /// <returns>A collection of <see cref="Planet"/></returns>
        public static async Task<IEnumerable<Planet>> GetPlanetInformationByRegionAsync(IEnumerable<int> regionIds)
        {
            var constellationIds = new List<int>();
            var regions = await GetRegionInformationAsync(regionIds);

            foreach (var region in regions)
            {
                constellationIds.AddRange(region.Constellations);
            }

            return await GetPlanetInformationByConstellationAsync(constellationIds);
        }
        #region Planet

        #endregion

        #region Moon

        #endregion
        #endregion

        #region Moon
        /// <summary>
        /// Get information for a moon
        /// </summary>
        /// <param name="moonId">Moon id</param>
        /// <returns>A <see cref="Moon"/></returns>
        public static async Task<Moon> GetMoonInformationAsync(int moonId)
        {
            string url = GetMoonInformation(moonId);
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsObjectAsync<Moon>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a set of moons
        /// </summary>
        /// <param name="moonIds">Moon ids</param>
        /// <returns>A collection of <see cref="Moon"/></returns>
        public static async Task<IEnumerable<Moon>> GetMoonInformationAsync(IEnumerable<int> moonIds)
        {
            var urls = new List<string>();
            foreach (var id in moonIds)
            {
                urls.Add(GetMoonInformation(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);

            return await ESI.ReadResponsesAsObjectsAsync<Moon>(responses);
        }

        /// <summary>
        /// Get information for moons around a given planet
        /// </summary>
        /// <param name="planetId">Planet id</param>
        /// <returns>A collection of <see cref="Moon"/></returns>
        public static async Task<IEnumerable<Moon>> GetMoonInformationByPlanetAsync(int planetId)
        {
            var planet = await GetPlanetInformationAsync(planetId);
            var system = await GetSolarSystemInformationAsync(planet.SystemID);
            var moonIds = system.Planets.First(p => p.ID == planetId).Moons.ToList();

            return await GetMoonInformationAsync(moonIds);
        }

        /// <summary>
        /// Get information for moons around a given set of planets
        /// </summary>
        /// <param name="planetIds">Planet ids</param>
        /// <returns>A collection of <see cref="Moon"/></returns>
        public static async Task<IEnumerable<Moon>> GetMoonInformationByPlanetAsync(IEnumerable<int> planetIds)
        {
            var planets = await GetPlanetInformationAsync(planetIds);

            var systemIds = planets.Select(p => p.SystemID).Distinct().ToList();
            var systems = await GetSolarSystemInformationAsync(systemIds);

            var moonIds = new List<int>();
            foreach (var system in systems)
            {
                planets = system.Planets.Where(p => planetIds.Any(id => id == p.ID)).ToList();
                foreach (var planet in planets)
                {
                    moonIds.AddRange(planet.Moons);
                }
            }

            return await GetMoonInformationAsync(moonIds);
        }

        /// <summary>
        /// Get information for moons in a given solar system
        /// </summary>
        /// <param name="systemId">Solar System id</param>
        /// <returns>A <see cref="Moon"/></returns>
        public static async Task<IEnumerable<Moon>> GetMoonInformationBySolarSystemAsync(int systemId)
        {
            var moonIds = new List<int>();
            var system = await GetSolarSystemInformationAsync(systemId);

            foreach (var planet in system.Planets)
            {
                moonIds.AddRange(planet.Moons);
            }

            return await GetMoonInformationAsync(moonIds);
        }

        /// <summary>
        /// Get information for moons in a given set of solar systems
        /// </summary>
        /// <param name="systemIds">Solar System ids</param>
        /// <returns>A collection of <see cref="Moon"/></returns>
        public static async Task<IEnumerable<Moon>> GetMoonInformationBySolarSystemAsync(IEnumerable<int> systemIds)
        {
            var moonIds = new List<int>();
            var systems = await GetSolarSystemInformationAsync(systemIds);

            foreach (var system in systems)
            {
                foreach (var planet in system.Planets)
                {
                    moonIds.AddRange(planet.Moons);
                }
            }

            return await GetMoonInformationAsync(moonIds);
        }

        /// <summary>
        /// Get information for moons in a given constellation
        /// </summary>
        /// <param name="constellationId">Constellation id</param>
        /// <returns>A collection of <see cref="Moon"/></returns>
        public static async Task<IEnumerable<Moon>> GetMoonInformationByConstellationAsync(int constellationId)
        {
            var constellation = await GetConstellationInformationAsync(constellationId);

            return await GetMoonInformationBySolarSystemAsync(constellation.Systems);
        }

        /// <summary>
        /// Get information for moons in a given set of constellations
        /// </summary>
        /// <param name="constellationIds">Constellation ids</param>
        /// <returns>A collection of <see cref="Moon"/></returns>
        public static async Task<IEnumerable<Moon>> GetMoonInformationByConstellationAsync(IEnumerable<int> constellationIds)
        {
            var systemIds = new List<int>();
            var constellations = await GetConstellationInformationAsync(constellationIds);

            foreach (var constellation in constellations)
            {
                systemIds.AddRange(constellation.Systems);
            }

            return await GetMoonInformationBySolarSystemAsync(systemIds);
        }

        /// <summary>
        /// Get information for moons in a given region
        /// </summary>
        /// <param name="regionId">Region id</param>
        /// <returns>A collection of <see cref="Moon"/></returns>
        public static async Task<IEnumerable<Moon>> GetMoonInformationByRegionAsync(int regionId)
        {
            var region = await GetRegionInformationAsync(regionId);

            return await GetMoonInformationByConstellationAsync(region.Constellations);
        }

        /// <summary>
        /// Get information for moons in a given set of regions
        /// </summary>
        /// <param name="regionIds">Region ids</param>
        /// <returns>A collection of <see cref="Moon"/></returns>
        public static async Task<IEnumerable<Moon>> GetMoonInformationByRegionAsync(IEnumerable<int> regionIds)
        {
            var constellationIds = new List<int>();
            var regions = await GetRegionInformationAsync(regionIds);

            foreach (var region in regions)
            {
                constellationIds.AddRange(region.Constellations);
            }

            return await GetMoonInformationByConstellationAsync(constellationIds);
        }
        #endregion
        #endregion

        #region Station/Structure/Stargate
        #region Station
        /// <summary>
        /// Get information for a given station
        /// </summary>
        /// <param name="stationId">Station id</param>
        /// <returns>A <see cref="Station"/></returns>
        public static async Task<Station> GetStationInformationAsync(int stationId)
        {
            string url = GetStationInformation(stationId);
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsObjectAsync<Station>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a set of stations
        /// </summary>
        /// <param name="stationIds">Station ids</param>
        /// <returns>A collection of <see cref="Station"/></returns>
        public static async Task<IEnumerable<Station>> GetStationInformationAsync(IEnumerable<int> stationIds)
        {
            var urls = new List<string>();
            foreach (var id in stationIds)
            {
                urls.Add(GetStationInformation(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);

            return await ESI.ReadResponsesAsObjectsAsync<Station>(responses);
        }
        #endregion

        #region Structure
        /// <summary>
        /// Get a list of structure ids
        /// </summary>
        /// <returns>A collection of structure ids</returns>
        public static async Task<IEnumerable<long>> ListAllPublicStructuresAsync()
        {
            string url = ListAllPublicStructures();
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsArrayAsync<long>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a given structure
        /// </summary>
        /// <param name="structureId">Structure id</param>
        /// <returns>A <see cref="Structure"/></returns>
        public static async Task<Structure> GetStructureInformationAsync(long structureId)
        {
            string url = GetStructureInformation(structureId);
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsObjectAsync<Structure>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a set of structures
        /// </summary>
        /// <param name="structureIds">Structure ids</param>
        /// <returns>A collection of <see cref="Structure"/></returns>
        public static async Task<IEnumerable<Structure>> GetStructureInformationAsync(IEnumerable<long> structureIds)
        {
            var urls = new List<string>();
            foreach (var id in structureIds)
            {
                urls.Add(GetStructureInformation(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);

            return await ESI.ReadResponsesAsObjectsAsync<Structure>(responses);
        }
        #endregion

        #region Stargate
        /// <summary>
        /// Get information for a given stargate
        /// </summary>
        /// <param name="stargateId">Stargate id</param>
        /// <returns>A <see cref="Stargate"/></returns>
        public static async Task<Stargate> GetStargateInformationAsync(int stargateId)
        {
            string url = GetStargateInformation(stargateId);
            var responses = await ESI.MakeEsiRequestsAsync(new List<string>() { url });

            return await ESI.ReadResponseAsObjectAsync<Stargate>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a set of stargates
        /// </summary>
        /// <param name="stargateIds">Stargate ids</param>
        /// <returns>A collection of <see cref="Stargate"/></returns>
        public static async Task<IEnumerable<Stargate>> GetStargateInformationAsync(IEnumerable<int> stargateIds)
        {
            var urls = new List<string>();
            foreach (var id in stargateIds)
            {
                urls.Add(GetStargateInformation(id));
            }

            var responses = await ESI.MakeEsiRequestsAsync(urls);

            return await ESI.ReadResponsesAsObjectsAsync<Stargate>(responses);
        }

        /// <summary>
        /// Get information for stargates in a given solar system
        /// </summary>
        /// <param name="systemId">Solar System id</param>
        /// <returns>A collection of <see cref="Stargate"/></returns>
        public static async Task<IEnumerable<Stargate>> GetStargateInformationBySolarSystemAsync(int systemId)
        {
            var system = await GetSolarSystemInformationAsync(systemId);

            return await GetStargateInformationAsync(system.Stargates);
        }

        /// <summary>
        /// Get information for stargates in a given set of solar system
        /// </summary>
        /// <param name="systemIds">Solar System ids</param>
        /// <returns>A collection of <see cref="Stargate"/></returns>
        public static async Task<IEnumerable<Stargate>> GetStargateInformationBySolarSystemAsync(IEnumerable<int> systemIds)
        {
            var stargateIds = new List<int>();
            var systems = await GetSolarSystemInformationAsync(systemIds);

            foreach (var system in systems)
            {
                stargateIds.AddRange(system.Stargates);
            }

            return await GetStargateInformationAsync(stargateIds);
        }

        /// <summary>
        /// Get information for stargates in a given constellation
        /// </summary>
        /// <param name="constellationId">Constellation id</param>
        /// <returns>A collection of <see cref="Stargate"/></returns>
        public static async Task<IEnumerable<Stargate>> GetStargateInformationByConstellationAsync(int constellationId)
        {
            var constellation = await GetConstellationInformationAsync(constellationId);

            return await GetStargateInformationBySolarSystemAsync(constellation.Systems);
        }

        /// <summary>
        /// Get information for stargates in a given set of constellations
        /// </summary>
        /// <param name="constellationIds">Constellation ids</param>
        /// <returns>A collection of <see cref="Stargate"/></returns>
        public static async Task<IEnumerable<Stargate>> GetStargateInformationByConstellationAsync(IEnumerable<int> constellationIds)
        {
            var systemIds = new List<int>();
            var constellations = await GetConstellationInformationAsync(constellationIds);

            foreach (var constellation in constellations)
            {
                systemIds.AddRange(constellation.Systems);
            }

            return await GetStargateInformationBySolarSystemAsync(systemIds);
        }

        /// <summary>
        /// Get information for stargates in a given region
        /// </summary>
        /// <param name="regionId">Region id</param>
        /// <returns>A collection of <see cref="Stargate"/></returns>
        public static async Task<IEnumerable<Stargate>> GetStargateInformationByRegionAsync(int regionId)
        {
            var region = await GetRegionInformationAsync(regionId);

            return await GetStargateInformationByConstellationAsync(region.Constellations);
        }

        /// <summary>
        /// Get information for stargates in a given set of regions
        /// </summary>
        /// <param name="regionIds">Region ids</param>
        /// <returns>A collection of <see cref="Stargate"/></returns>
        public static async Task<IEnumerable<Stargate>> GetStargateInformationByRegionAsync(IEnumerable<int> regionIds)
        {
            var systemIds = new List<int>();
            var regions = await GetRegionInformationAsync(regionIds);

            foreach (var region in regions)
            {
                systemIds.AddRange(region.Constellations);
            }

            return await GetStargateInformationByConstellationAsync(systemIds);
        }
        #endregion
        #endregion
        #endregion
    }
}
