using ESI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ESI
{
    public static class ESI
    {
        /// <summary>
        /// Gets a response for the given request
        /// </summary>
        /// <param name="request">Request to make</param>
        /// <returns>An http response</returns>
        public static async Task<IEnumerable<HttpResponseMessage>> MakeEsiRequestsAsync(IEnumerable<string> urls)
        {
            var client = new HttpClient();

            // Start requests for the given urls
            var requests = urls.Select(url => client.GetAsync(url)).ToList();

            // Wait for all the requests to finish
            await Task.WhenAll(requests);

            // Get the responses
            var responses = requests.Select(task => task.Result).ToList();

            return responses;
        }

        /// <summary>
        /// Reads responses as arrays into a collection of a given type
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="responses">Http responses</param>
        /// <param name="errorMsg">Error message</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ReadResponsesAsArraysAsync<T>(IEnumerable<HttpResponseMessage> responses, string errorMsg = "")
        {
            List<T> list = new List<T>();
            foreach (var response in responses)
            {
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<T> temp = new List<T>();
                    temp = await response.Content.ReadAsAsync<IEnumerable<T>>();
                    list.AddRange(temp);
                }
                else
                {
                    throw new Exception(errorMsg);
                }
            }

            return list;
        }

        /// <summary>
        /// Reads responses as single objects into a collection of a given type
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="responses">Http responses</param>
        /// <param name="errorMsg">Error message</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ReadResponsesAsObjectsAsync<T>(IEnumerable<HttpResponseMessage> responses, string errorMsg = "")
        {
            List<T> list = new List<T>();
            foreach (var response in responses)
            {
                if (response.IsSuccessStatusCode)
                {
                    var temp = await response.Content.ReadAsAsync<T>();
                    list.Add(temp);
                }
                else
                {
                    throw new Exception(errorMsg);
                }
            }

            return list;
        }

        /// <summary>
        /// Reads a response as an array into a given type
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="response">Http response</param>
        /// <param name="errorMsg">Error message</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> ReadResponseAsArrayAsync<T>(HttpResponseMessage response, string errorMsg = "")
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<T>>();
            }
            else
            {
                throw new Exception(errorMsg);
            }
        }

        /// <summary>
        /// Reads a response as a single object into a given type
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="response">Http response</param>
        /// <param name="errorMsg">Error message</param>
        /// <returns></returns>
        public static async Task<T> ReadResponseAsObjectAsync<T>(HttpResponseMessage response, string errorMsg = "")
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new Exception(errorMsg);
            }
        }

        #region Market

        #endregion

        #region Universe
        #region Race/Bloodline/Ancestry
        #region Race
        /// <summary>
        /// Get a list of races
        /// </summary>
        /// <returns>A collection of <see cref="Race"/></returns>
        public static async Task<IEnumerable<Race>> GetCharacterRacesAsync()
        {
            string url = Universe.GetBloodlines();
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsArrayAsync<Race>(responses.ElementAt(0));
        }
        #endregion

        #region Bloodline
        /// <summary>
        /// Get a list of bloodlines
        /// </summary>
        /// <returns>A collection of <see cref="Bloodline"/></returns>
        public static async Task<IEnumerable<Bloodline>> GetBloodlinesAsync()
        {
            string url = Universe.GetBloodlines();
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsArrayAsync<Bloodline>(responses.ElementAt(0));
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
            string url = Universe.GetAncestries();
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsArrayAsync<Ancestry>(responses.ElementAt(0));
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
            string url = Universe.GetItemCategories();
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsArrayAsync<int>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information of an item category
        /// </summary>
        /// <param name="categoryId">Category id</param>
        /// <returns>A <see cref="Category"/></returns>
        public static async Task<Category> GetItemCategoryInformationAsync(int categoryId)
        {
            string url = Universe.GetItemCategoryInformation(categoryId);
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsObjectAsync<Category>(responses.ElementAt(0));
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
                urls.Add(Universe.GetItemCategoryInformation(id));
            }

            var responses = await MakeEsiRequestsAsync(urls);

            return await ReadResponsesAsObjectsAsync<Category>(responses);
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
                string url = Universe.GetItemGroups(i);
                var responses = await MakeEsiRequestsAsync(new List<string>() { url });

                responseIds = await ReadResponseAsArrayAsync<int>(responses.ElementAt(0));
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
            string url = Universe.GetItemGroupInformation(groupId);
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsObjectAsync<Group>(responses.ElementAt(0));
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
                urls.Add(Universe.GetItemGroupInformation(id));
            }

            var responses = await MakeEsiRequestsAsync(urls);

            return await ReadResponsesAsObjectsAsync<Group>(responses);
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
            string url = Universe.GetTypeInformation(typeId);
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsObjectAsync<Item>(responses.ElementAt(0));
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
                urls.Add(Universe.GetTypeInformation(id));
            }

            var responses = await MakeEsiRequestsAsync(urls);

            return await ReadResponsesAsObjectsAsync<Item>(responses);
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
            string url = Universe.GetRegions();
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsArrayAsync<int>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a region
        /// </summary>
        /// <returns>A <see cref="Region"/></returns>
        public static async Task<Region> GetRegionInformationAsync(int regionId)
        {
            string url = Universe.GetRegionInformation(regionId);
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsObjectAsync<Region>(responses.ElementAt(0));
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
                urls.Add(Universe.GetRegionInformation(id));
            }

            var responses = await MakeEsiRequestsAsync(urls);

            return await ReadResponsesAsObjectsAsync<Region>(responses);
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
            string url = Universe.GetConstellations();
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsArrayAsync<int>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a constellation
        /// </summary>
        /// <param name="constellationId">Constellation id</param>
        /// <returns>A <see cref="Constellation"/></returns>
        public static async Task<Constellation> GetConstellationInformationAsync(int constellationId)
        {
            string url = Universe.GetConstellationInformation(constellationId);
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsObjectAsync<Constellation>(responses.ElementAt(0));
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
                urls.Add(Universe.GetConstellationInformation(id));
            }

            var responses = await MakeEsiRequestsAsync(urls);

            return await ReadResponsesAsObjectsAsync<Constellation>(responses);
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
            string url = Universe.GetSolarSystems();
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsArrayAsync<int>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a solar system
        /// </summary>
        /// <param name="systemId">Solar System id</param>
        /// <returns>A <see cref="SolarSystem"/></returns>
        public static async Task<SolarSystem> GetSolarSystemInformationAsync(int systemId)
        {
            string url = Universe.GetSolarSystemInformation(systemId);
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsObjectAsync<SolarSystem>(responses.ElementAt(0));
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
                urls.Add(Universe.GetSolarSystemInformation(id));
            }

            var responses = await MakeEsiRequestsAsync(urls);

            return await ReadResponsesAsObjectsAsync<SolarSystem>(responses);
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
            string url = Universe.GetStarInformation(starId);
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsObjectAsync<Star>(responses.ElementAt(0));
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
                urls.Add(Universe.GetStarInformation(id));
            }

            var responses = await MakeEsiRequestsAsync(urls);

            return await ReadResponsesAsObjectsAsync<Star>(responses);
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

            foreach(var system in systems)
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
            string url = Universe.GetPlanetInformation(planetId);
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });
            var planet = await ReadResponseAsObjectAsync<Planet>(responses.ElementAt(0));
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
                urls.Add(Universe.GetPlanetInformation(id));
            }

            var responses = await MakeEsiRequestsAsync(urls);
            var planets = await ReadResponsesAsObjectsAsync<Planet>(responses);

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

            foreach(var planet in system.Planets)
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
            string url = Universe.GetMoonInformation(moonId);
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsObjectAsync<Moon>(responses.ElementAt(0));
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
                urls.Add(Universe.GetMoonInformation(id));
            }

            var responses = await MakeEsiRequestsAsync(urls);

            return await ReadResponsesAsObjectsAsync<Moon>(responses);
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
            string url = Universe.GetStationInformation(stationId);
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsObjectAsync<Station>(responses.ElementAt(0));
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
                urls.Add(Universe.GetStationInformation(id));
            }

            var responses = await MakeEsiRequestsAsync(urls);

            return await ReadResponsesAsObjectsAsync<Station>(responses);
        }
        #endregion

        #region Structure
        /// <summary>
        /// Get a list of structure ids
        /// </summary>
        /// <returns>A collection of structure ids</returns>
        public static async Task<IEnumerable<long>> ListAllPublicStructuresAsync()
        {
            string url = Universe.ListAllPublicStructures();
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsArrayAsync<long>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a given structure
        /// </summary>
        /// <param name="structureId">Structure id</param>
        /// <returns>A <see cref="Structure"/></returns>
        public static async Task<Structure> GetStructureInformationAsync(long structureId)
        {
            string url = Universe.GetStructureInformation(structureId);
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsObjectAsync<Structure>(responses.ElementAt(0));
        }

        /// <summary>
        /// Get information for a set of structures
        /// </summary>
        /// <param name="structureIds">Structure ids</param>
        /// <returns>A collection of <see cref="Structure"/></returns>
        public static async Task<IEnumerable<Structure>> GetStructureInformationAsync(IEnumerable<int> structureIds)
        {
            var urls = new List<string>();
            foreach (var id in structureIds)
            {
                urls.Add(Universe.GetStationInformation(id));
            }

            var responses = await MakeEsiRequestsAsync(urls);

            return await ReadResponsesAsObjectsAsync<Structure>(responses);
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
            string url = Universe.GetStargateInformation(stargateId);
            var responses = await MakeEsiRequestsAsync(new List<string>() { url });

            return await ReadResponseAsObjectAsync<Stargate>(responses.ElementAt(0));
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
                urls.Add(Universe.GetStargateInformation(id));
            }

            var responses = await MakeEsiRequestsAsync(urls);

            return await ReadResponsesAsObjectsAsync<Stargate>(responses);
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
