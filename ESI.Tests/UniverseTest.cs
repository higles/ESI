using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ESI.Tests
{
    public class UniverseTest
    {
        #region Race/Bloodline/Ancestry
        #region Race
        [Fact]
        public async Task GettingAllRacesIsNotNullOrEmpty()
        {
            var races = await Universe.GetCharacterRacesAsync();
            Assert.NotNull(races);
            Assert.NotEmpty(races);
        }
        #endregion

        #region Bloodline
        [Fact]
        public async Task GettingAllBloodlinesIsNotNullOrEmpty()
        {
            var bloodlines = await Universe.GetBloodlinesAsync();
            Assert.NotNull(bloodlines);
            Assert.NotEmpty(bloodlines);
        }

        [Fact]
        public async Task GetCorrectBloodlinesForARace()
        {
            int raceId = 1;
            var bloodlines = await Universe.GetBloodlinesByRaceAsync(raceId);

            Assert.NotNull(bloodlines);
            Assert.NotEmpty(bloodlines);
            Assert.Equal(3, bloodlines.Count());

            foreach (var bloodline in bloodlines)
            {
                Assert.Equal(raceId, bloodline.RaceID);
            }
        }

        [Fact]
        public async Task GetCorrectBloodlinesForASetOfRaces()
        {
            var raceIds = new List<int>() { 1, 2 };
            var bloodlines = await Universe.GetBloodlinesByRaceAsync(raceIds);

            Assert.NotNull(bloodlines);
            Assert.NotEmpty(bloodlines);
            Assert.Equal(6, bloodlines.Count());

            foreach (var bloodline in bloodlines)
            {
                Assert.Contains(bloodline.RaceID, raceIds);
            }
        }

        [Fact]
        public async Task GetNoBloodlinesFromBadRaceId()
        {
            var raceId = 3;
            var bloodlines = await Universe.GetBloodlinesByRaceAsync(raceId);

            Assert.Empty(bloodlines);
        }
        #endregion

        #region Ancestry
        [Fact]
        public async Task GettingAllAncestriesIsNotNullOrEmpty()
        {
            var ancestries = await Universe.GetAncestriesAsync();
            Assert.NotNull(ancestries);
            Assert.NotEmpty(ancestries);
        }

        [Fact]
        public async Task GetCorrectAncestriesForABloodline()
        {
            int bloodlineId = 1;
            var ancestries = await Universe.GetAncestriesByBloodlineAsync(bloodlineId);

            Assert.NotNull(ancestries);
            Assert.NotEmpty(ancestries);
            Assert.Equal(3, ancestries.Count());

            foreach (var ancestry in ancestries)
            {
                Assert.Equal(ancestry.BloodlineID, bloodlineId);
            }
        }

        [Fact]
        public async Task GetCorrectAncestriesForASetOfBloodlines()
        {
            var bloodlineIds = new List<int>() { 1, 2 };
            var ancestries = await Universe.GetAncestriesByBloodlineAsync(bloodlineIds);

            Assert.NotNull(ancestries);
            Assert.NotEmpty(ancestries);
            Assert.Equal(6, ancestries.Count());

            foreach (var ancestry in ancestries)
            {
                Assert.Contains(ancestry.BloodlineID, bloodlineIds);
            }
        }

        [Fact]
        public async Task GetNoAncestriesFromBadBloodlineId()
        {
            var bloodlineId = 20;
            var ancestries = await Universe.GetAncestriesByBloodlineAsync(bloodlineId);

            Assert.Empty(ancestries);
        }

        [Fact]
        public async Task GetCorrectAncestriesForARace()
        {
            int raceId = 1;
            var ancestries = await Universe.GetAncestriesByRaceAsync(raceId);
            var bloodlines = await Universe.GetBloodlinesByRaceAsync(raceId);
            var bloodlineIds = bloodlines.Select(b => b.ID).ToList();

            Assert.NotNull(ancestries);
            Assert.NotEmpty(ancestries);
            Assert.Equal(9, ancestries.Count());

            foreach (var ancestry in ancestries)
            {
                Assert.Contains(ancestry.BloodlineID, bloodlineIds);
            }
        }

        [Fact]
        public async Task GetCorrectAncestriesForASetOfRaces()
        {
            var raceIds = new List<int>() { 1, 2 };
            var ancestries = await Universe.GetAncestriesByRaceAsync(raceIds);
            var bloodlines = await Universe.GetBloodlinesByRaceAsync(raceIds);
            var bloodlineIds = bloodlines.Select(b => b.ID).ToList();

            Assert.NotNull(ancestries);
            Assert.NotEmpty(ancestries);
            Assert.Equal(18, ancestries.Count());

            foreach (var ancestry in ancestries)
            {
                Assert.Contains(ancestry.BloodlineID, bloodlineIds);
            }
        }

        [Fact]
        public async Task GetNoAncestriesFromBadRaceId()
        {
            var raceId = 3;
            var ancestries = await Universe.GetBloodlinesByRaceAsync(raceId);

            Assert.Empty(ancestries);
        }
        #endregion
        #endregion

        #region Category/Group/Item
        #region Category
        [Fact]
        public async Task GettingAllCategoriesIsNotNullOrEmpty()
        {
            var categories = await Universe.GetItemCategoriesAsync();
            Assert.NotNull(categories);
            Assert.NotEmpty(categories);
        }

        [Fact]
        public async Task CanGetInformationForCategory()
        {
            int categoryId = 6;
            var category = await Universe.GetItemCategoryInformationAsync(categoryId);

            Assert.NotNull(category);
            Assert.Equal(categoryId, category.ID);
        }

        [Fact]
        public async Task CanGetInformationForCategories()
        {
            List<int> categoryIds = new List<int>() { 6, 42, 43 };
            var categories = await Universe.GetItemCategoryInformationAsync(categoryIds);

            Assert.NotNull(categories);
            Assert.Equal(categoryIds.Count(), categories.Count());

            foreach(var id in categoryIds)
            {
                Assert.Contains(categories, c => c.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForAllCategories()
        {
            var categoryIds = await Universe.GetItemCategoriesAsync();
            var categories = await Universe.GetItemCategoryInformationAsync();

            Assert.NotNull(categories);
            Assert.Equal(categoryIds.Count(), categories.Count());

            foreach (var id in categoryIds)
            {
                Assert.Contains(categories, c => c.ID == id);
            }
        }
        #endregion

        #region Group
        [Fact]
        public async Task GettingAllGroupsIsNotNullOrEmpty()
        {
            var groups = await Universe.GetItemGroupsAsync();
            Assert.NotNull(groups);
            Assert.NotEmpty(groups);
        }

        [Fact]
        public async Task CanGetInformationForGroup()
        {
            int groupId = 1042;
            var group = await Universe.GetItemGroupInformationAsync(groupId);

            Assert.NotNull(group);
            Assert.Equal(groupId, group.ID);
        }

        [Fact]
        public async Task CanGetInformationForGroups()
        {
            List<int> groupIds = new List<int>() { 1042, 1034, 1040, 1041 };
            var groups = await Universe.GetItemGroupInformationAsync(groupIds);

            Assert.NotNull(groups);
            Assert.Equal(groupIds.Count(), groups.Count());

            foreach (var id in groupIds)
            {
                Assert.Contains(groups, g => g.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForAllGroups()
        {
            var groupIds = await Universe.GetItemGroupsAsync();
            var groups = await Universe.GetItemGroupInformationAsync();

            Assert.NotNull(groups);
            Assert.Equal(groupIds.Count(), groups.Count());

            foreach (var id in groupIds)
            {
                Assert.Contains(groups, g => g.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForGroupsInACategory()
        {
            var categoryId = 42;
            var groups = await Universe.GetItemGroupInformationByCategoryAsync(categoryId);
            var category = await Universe.GetItemCategoryInformationAsync(categoryId);

            Assert.NotNull(groups);
            Assert.Equal(category.Groups.Count, groups.Count());

            foreach (var id in category.Groups)
            {
                Assert.Contains(groups, g => g.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForGroupsInCategories()
        {
            List<int> categoryIds = new List<int>() { 6, 42, 43 };
            var groups = await Universe.GetItemGroupInformationByCategoryAsync(categoryIds);
            var categories = await Universe.GetItemCategoryInformationAsync(categoryIds);

            var groupIdCount = categories.Sum(c => c.Groups.Count);

            Assert.NotNull(groups);
            Assert.Equal(groupIdCount, groups.Count());

            foreach (var category in categories)
            {
                foreach (var id in category.Groups)
                {
                    Assert.Contains(groups, g => g.ID == id);
                }
            }
        }
        #endregion

        #region Item
        [Fact]
        public async Task GettingAllItemsIsNotNullOrEmpty()
        {
            var items = await Universe.GetTypesAsync();
            Assert.NotNull(items);
            Assert.NotEmpty(items);
        }

        [Fact]
        public async Task CanGetInformationForItem()
        {
            int itemId = 600;
            var item = await Universe.GetTypeInformationAsync(itemId);

            Assert.NotNull(item);
            Assert.Equal(itemId, item.ID);
        }

        [Fact]
        public async Task CanGetInformationForItems()
        {
            List<int> itemIds = new List<int>() { 600, 4200, 11000 };
            var items = await Universe.GetTypeInformationAsync(itemIds);

            Assert.NotNull(items);
            Assert.Equal(itemIds.Count(), items.Count());

            foreach (var id in itemIds)
            {
                Assert.Contains(items, i => i.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForAllItems()
        {
            var itemIds = await Universe.GetTypesAsync();
            var items = await Universe.GetTypeInformationAsync();

            Assert.NotNull(items);
            Assert.Equal(itemIds.Count(), items.Count());

            foreach (var id in itemIds)
            {
                Assert.Contains(items, i => i.ID == id);
            }
        }
        
        [Fact]
        public async Task CanGetInformationForItemsInAGroup()
        {
            var groupId = 1042;
            var items = await Universe.GetTypeInformationByGroupAsync(groupId);
            var group = await Universe.GetItemGroupInformationAsync(groupId);

            Assert.NotNull(items);
            Assert.Equal(group.Types.Count, items.Count());

            foreach (var id in group.Types)
            {
                Assert.Contains(items, i => i.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForItemsInGroups()
        {
            List<int> groupIds = new List<int>() { 1042, 1034, 1040, 1041 };
            var items = await Universe.GetTypeInformationByGroupAsync(groupIds);
            var groups = await Universe.GetItemGroupInformationAsync(groupIds);

            var itemIdCount = groups.Sum(g => g.Types.Count);

            Assert.NotNull(items);
            Assert.Equal(itemIdCount, items.Count());

            foreach (var group in groups)
            {
                foreach (var id in group.Types)
                {
                    Assert.Contains(items, i => i.ID == id);
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForItemsInACategory()
        {
            var categoryId = 42;
            var items = await Universe.GetTypeInformationByCategoryAsync(categoryId);
            var groups = await Universe.GetItemGroupInformationByCategoryAsync(categoryId);

            var itemIdCount = groups.Sum(g => g.Types.Count);

            Assert.NotNull(items);
            Assert.Equal(itemIdCount, items.Count());

            foreach (var group in groups)
            {
                foreach (var id in group.Types)
                {
                    Assert.Contains(items, i => i.ID == id);
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForItemsInCategories()
        {
            List<int> categoryIds = new List<int>() { 6, 42, 43 };
            var items = await Universe.GetTypeInformationByCategoryAsync(categoryIds);
            var groups = await Universe.GetItemGroupInformationByCategoryAsync(categoryIds);

            var itemIdCount = groups.Sum(g => g.Types.Count);

            Assert.NotNull(items);
            Assert.Equal(itemIdCount, items.Count());

            foreach (var group in groups)
            {
                foreach (var id in group.Types)
                {
                    Assert.Contains(items, i => i.ID == id);
                }
            }
        }
        #endregion
        #endregion

        #region Region/Constellation/System/Star/Planet/Moon/Asteroid Belt
        #region Region
        [Fact]
        public async Task GettingAllRegionsIsNotNullOrEmpty()
        {
            var regions = await Universe.GetRegionsAsync();
            Assert.NotNull(regions);
            Assert.NotEmpty(regions);
        }

        [Fact]
        public async Task CanGetInformationForRegion()
        {
            int regionId = 10000002;
            var region = await Universe.GetRegionInformationAsync(regionId);

            Assert.NotNull(region);
            Assert.Equal(regionId, region.ID);
        }

        [Fact]
        public async Task CanGetInformationForRegions()
        {
            List<int> regionIds = new List<int>() { 10000002, 10000032, 10000043 };
            var regions = await Universe.GetRegionInformationAsync(regionIds);

            Assert.NotNull(regions);
            Assert.Equal(regionIds.Count(), regions.Count());

            foreach (var id in regionIds)
            {
                Assert.Contains(regions, c => c.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForAllRegions()
        {
            var regionIds = await Universe.GetRegionsAsync();
            var regions = await Universe.GetRegionInformationAsync();

            Assert.NotNull(regions);
            Assert.Equal(regionIds.Count(), regions.Count());

            foreach (var id in regionIds)
            {
                Assert.Contains(regions, c => c.ID == id);
            }
        }
        #endregion

        #region Constellation
        [Fact]
        public async Task GettingAllConstellationsIsNotNullOrEmpty()
        {
            var constellations = await Universe.GetConstellationsAsync();
            Assert.NotNull(constellations);
            Assert.NotEmpty(constellations);
        }

        [Fact]
        public async Task CanGetInformationForConstellation()
        {
            int constellationId = 20000020;
            var constellation = await Universe.GetConstellationInformationAsync(constellationId);

            Assert.NotNull(constellation);
            Assert.Equal(constellationId, constellation.ID);
        }

        [Fact]
        public async Task CanGetInformationForConstellations()
        {
            List<int> constellationIds = new List<int>() { 20000020, 20000389, 20000322 };
            var constellations = await Universe.GetConstellationInformationAsync(constellationIds);

            Assert.NotNull(constellations);
            Assert.Equal(constellationIds.Count(), constellations.Count());

            foreach (var id in constellationIds)
            {
                Assert.Contains(constellations, c => c.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForAllConstellations()
        {
            var constellationIds = await Universe.GetConstellationsAsync();
            var constellations = await Universe.GetConstellationInformationAsync();

            Assert.NotNull(constellations);
            Assert.Equal(constellationIds.Count(), constellations.Count());

            foreach (var id in constellationIds)
            {
                Assert.Contains(constellations, c => c.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForConstellationsInARegion()
        {
            var regionId = 10000002;
            var constellations = await Universe.GetConstellationInformationByRegionAsync(regionId);
            var region = await Universe.GetRegionInformationAsync(regionId);

            Assert.NotNull(constellations);
            Assert.Equal(region.Constellations.Count, constellations.Count());

            foreach (var id in region.Constellations)
            {
                Assert.Contains(constellations, c => c.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForConstellationsInRegions()
        {
            List<int> regionIds = new List<int>() { 10000002, 10000032, 10000043 };
            var constellations = await Universe.GetConstellationInformationByRegionAsync(regionIds);
            var regions = await Universe.GetRegionInformationAsync(regionIds);

            var constellationIdCount = regions.Sum(r => r.Constellations.Count);

            Assert.NotNull(constellations);
            Assert.Equal(constellationIdCount, constellations.Count());

            foreach (var region in regions)
            {
                foreach (var id in region.Constellations)
                {
                    Assert.Contains(constellations, c => c.ID == id);
                }
            }
        }
        #endregion

        #region System
        [Fact]
        public async Task GettingAllSolarSystemsIsNotNullOrEmpty()
        {
            var systems = await Universe.GetSolarSystemsAsync();
            Assert.NotNull(systems);
            Assert.NotEmpty(systems);
        }

        [Fact]
        public async Task CanGetInformationForSolarSystem()
        {
            int systemId = 30000142;
            var system = await Universe.GetSolarSystemInformationAsync(systemId);

            Assert.NotNull(system);
            Assert.Equal(systemId, system.ID);
        }

        [Fact]
        public async Task CanGetInformationForSolarSystems()
        {
            List<int> systemIds = new List<int>() { 30000142, 30002659, 30002187 };
            var systems = await Universe.GetSolarSystemInformationAsync(systemIds);

            Assert.NotNull(systems);
            Assert.Equal(systemIds.Count(), systems.Count());

            foreach (var id in systemIds)
            {
                Assert.Contains(systems, s => s.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForAllSolarSystems()
        {
            var systemIds = await Universe.GetSolarSystemsAsync();
            var systems = await Universe.GetSolarSystemInformationAsync();

            Assert.NotNull(systems);
            Assert.Equal(systemIds.Count(), systems.Count());

            foreach (var id in systemIds)
            {
                Assert.Contains(systems, s => s.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForSolarSystemsInAConstellation()
        {
            int constellationId = 20000020;
            var systems = await Universe.GetSolarSystemInformationByConstellationAsync(constellationId);
            var constellation = await Universe.GetConstellationInformationAsync(constellationId);

            Assert.NotNull(systems);
            Assert.Equal(constellation.Systems.Count, systems.Count());

            foreach (var id in constellation.Systems)
            {
                Assert.Contains(systems, s => s.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForSolarSystemsInConstellations()
        {
            List<int> constellationIds = new List<int>() { 20000020, 20000389, 20000322 };
            var systems = await Universe.GetSolarSystemInformationByConstellationAsync(constellationIds);
            var constellations = await Universe.GetConstellationInformationAsync(constellationIds);

            var systemIdCount = constellations.Sum(c => c.Systems.Count);

            Assert.NotNull(systems);
            Assert.Equal(systemIdCount, systems.Count());

            foreach (var constellation in constellations)
            {
                foreach (var id in constellation.Systems)
                {
                    Assert.Contains(systems, s => s.ID == id);
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForSolarSystemsInARegion()
        {
            var regionId = 10000002;
            var constellations = await Universe.GetConstellationInformationByRegionAsync(regionId);
            var systems = await Universe.GetSolarSystemInformationByRegionAsync(regionId);

            var systemIdCount = constellations.Sum(c => c.Systems.Count);

            Assert.NotNull(systems);
            Assert.Equal(systemIdCount, systems.Count());
            
            foreach (var constellation in constellations)
            {
                foreach (var id in constellation.Systems)
                {
                    Assert.Contains(systems, s => s.ID == id);
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForSolarSystemsInRegions()
        {
            List<int> regionIds = new List<int>() { 10000002, 10000032, 10000043 };
            var constellations = await Universe.GetConstellationInformationByRegionAsync(regionIds);
            var systems = await Universe.GetSolarSystemInformationByRegionAsync(regionIds);

            var systemIdCount = constellations.Sum(c => c.Systems.Count);

            Assert.NotNull(systems);
            Assert.Equal(systemIdCount, systems.Count());

            foreach (var constellation in constellations)
            {
                foreach (var id in constellation.Systems)
                {
                    Assert.Contains(systems, s => s.ID == id);
                }
            }
        }
        #endregion

        #region Star
        [Fact]
        public async Task CanGetInformationForStar()
        {
            int starId = 40009076;
            var star = await Universe.GetStarInformationAsync(starId);

            Assert.NotNull(star);
        }

        [Fact]
        public async Task CanGetInformationForStars()
        {
            List<int> starIds = new List<int>() { 40009076, 40169265, 40139383 };
            var stars = await Universe.GetStarInformationAsync(starIds);

            Assert.NotNull(stars);
            Assert.Equal(starIds.Count(), stars.Count());
        }

        [Fact]
        public async Task CanGetInformationForStarInASolarSystem()
        {
            int systemId = 30000142;
            var star = await Universe.GetStarInformationBySolarSystemAsync(systemId);
            var system = await Universe.GetSolarSystemInformationAsync(systemId);

            Assert.NotNull(star);
            Assert.Equal(system.ID, star.SolarSystemID);
        }

        [Fact]
        public async Task CanGetInformationForStarsInSolarSystems()
        {
            List<int> systemIds = new List<int>() { 30000142, 30002659, 30002187 };
            var stars = await Universe.GetStarInformationBySolarSystemAsync(systemIds);
            var systems = await Universe.GetSolarSystemInformationAsync(systemIds);

            Assert.NotNull(stars);
            Assert.Equal(systems.Count(), stars.Count());

            foreach (var id in systemIds)
            {
                Assert.Contains(stars, s => s.SolarSystemID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForStarsInAConstellation()
        {
            var constellationId = 20000020;
            var stars = await Universe.GetStarInformationByConstellationAsync(constellationId);
            var constellation = await Universe.GetConstellationInformationAsync(constellationId);

            Assert.NotNull(stars);
            Assert.Equal(constellation.Systems.Count(), stars.Count());

            foreach (var id in constellation.Systems)
            {
                Assert.Contains(stars, s => s.SolarSystemID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForStarsInConstellations()
        {
            List<int> constellationIds = new List<int>() { 20000020, 20000389, 20000322 };
            var stars = await Universe.GetStarInformationByConstellationAsync(constellationIds);
            var constellations = await Universe.GetConstellationInformationAsync(constellationIds);

            var systemIdCount = constellations.Sum(c => c.Systems.Count);

            Assert.NotNull(stars);
            Assert.Equal(systemIdCount, stars.Count());

            foreach (var constellation in constellations)
            {
                foreach (var id in constellation.Systems)
                {
                    Assert.Contains(stars, s => s.SolarSystemID == id);
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForStarsInARegion()
        {
            int regionId = 10000002;
            var stars = await Universe.GetStarInformationByRegionAsync(regionId);
            var constellations = await Universe.GetConstellationInformationByRegionAsync(regionId);

            var systemIdCount = constellations.Sum(c => c.Systems.Count);

            Assert.NotNull(stars);
            Assert.Equal(systemIdCount, stars.Count());

            foreach (var constellation in constellations)
            {
                foreach (var id in constellation.Systems)
                {
                    Assert.Contains(stars, s => s.SolarSystemID == id);
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForStarsInRegions()
        {
            List<int> regionIds = new List<int>() { 10000002, 10000032, 10000043 };
            var stars = await Universe.GetStarInformationByRegionAsync(regionIds);
            var constellations = await Universe.GetConstellationInformationByRegionAsync(regionIds);

            var systemIdCount = constellations.Sum(c => c.Systems.Count);

            Assert.NotNull(stars);
            Assert.Equal(systemIdCount, stars.Count());

            foreach (var constellation in constellations)
            {
                foreach (var id in constellation.Systems)
                {
                    Assert.Contains(stars, s => s.SolarSystemID == id);
                }
            }
        }
        #endregion

        #region Planet
        [Fact]
        public async Task CanGetInformationForPlanet()
        {
            int planetId = 40139384;
            var planet = await Universe.GetPlanetInformationAsync(planetId);

            Assert.NotNull(planet);
        }

        [Fact]
        public async Task CanGetInformationForPlanets()
        {
            List<int> planetIds = new List<int>() { 40139384, 40009077, 40169266 };
            var planets = await Universe.GetPlanetInformationAsync(planetIds);

            Assert.NotNull(planets);
            Assert.Equal(planetIds.Count(), planets.Count());
        }

        [Fact]
        public async Task CanGetInformationForPlanetsInASolarSystem()
        {
            int systemId = 30000142;
            var planets = await Universe.GetPlanetInformationBySolarSystemAsync(systemId);
            var system = await Universe.GetSolarSystemInformationAsync(systemId);

            Assert.NotNull(planets);
            Assert.Equal(system.Planets.Count(), planets.Count());

            foreach (var planet in system.Planets)
            {
                Assert.Contains(planets, p => p.ID == planet.ID);
            }
        }

        [Fact]
        public async Task CanGetInformationForPlanetsInSolarSystems()
        {
            List<int> systemIds = new List<int>() { 30000142, 30002659, 30002187 };
            var planets = await Universe.GetPlanetInformationBySolarSystemAsync(systemIds);
            var systems = await Universe.GetSolarSystemInformationAsync(systemIds);

            var planetCount = systems.Sum(s => s.Planets.Count);

            Assert.NotNull(planets);
            Assert.Equal(planetCount, planets.Count());

            foreach (var system in systems)
            {
                foreach (var planet in system.Planets)
                {
                    Assert.Contains(planets, p => p.ID == planet.ID);
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForPlanetsInAConstellation()
        {
            var constellationId = 20000020;
            var planets = await Universe.GetPlanetInformationByConstellationAsync(constellationId);
            var systems = await Universe.GetSolarSystemInformationByConstellationAsync(constellationId);

            var planetCount = systems.Sum(s => s.Planets.Count);

            Assert.NotNull(planets);
            Assert.Equal(planetCount, planets.Count());

            foreach (var system in systems)
            {
                foreach (var planet in system.Planets)
                {
                    Assert.Contains(planets, p => p.ID == planet.ID);
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForPlanetsInConstellations()
        {
            List<int> constellationIds = new List<int>() { 20000020, 20000389, 20000322 };
            var planets = await Universe.GetPlanetInformationByConstellationAsync(constellationIds);
            var systems = await Universe.GetSolarSystemInformationByConstellationAsync(constellationIds);

            var planetCount = systems.Sum(s => s.Planets.Count);

            Assert.NotNull(planets);
            Assert.Equal(planetCount, planets.Count());

            foreach (var system in systems)
            {
                foreach (var planet in system.Planets)
                {
                    Assert.Contains(planets, p => p.ID == planet.ID);
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForPlanetsInARegion()
        {
            int regionId = 10000002;
            var planets = await Universe.GetPlanetInformationByRegionAsync(regionId);
            var systems = await Universe.GetSolarSystemInformationByRegionAsync(regionId);

            var planetCount = systems.Sum(s => s.Planets.Count);

            Assert.NotNull(planets);
            Assert.Equal(planetCount, planets.Count());

            foreach (var system in systems)
            {
                foreach (var planet in system.Planets)
                {
                    Assert.Contains(planets, p => p.ID == planet.ID);
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForPlanetsInRegions()
        {
            List<int> regionIds = new List<int>() { 10000002, 10000032, 10000043 };
            var planets = await Universe.GetPlanetInformationByRegionAsync(regionIds);
            var systems = await Universe.GetSolarSystemInformationByRegionAsync(regionIds);

            var planetCount = systems.Sum(s => s.Planets.Count);

            Assert.NotNull(planets);
            Assert.Equal(planetCount, planets.Count());

            foreach (var system in systems)
            {
                foreach (var planet in system.Planets)
                {
                    Assert.Contains(planets, p => p.ID == planet.ID);
                }
            }
        }
        #endregion

        #region Moon
        [Fact]
        public async Task CanGetInformationForMoon()
        {
            int moonId = 40139396;
            var moon = await Universe.GetMoonInformationAsync(moonId);

            Assert.NotNull(moon);
            Assert.Equal(moonId, moon.ID);
        }

        [Fact]
        public async Task CanGetInformationForMoons()
        {
            List<int> moonIds = new List<int>() { 40139396, 40009089, 40169269 };
            var moons = await Universe.GetMoonInformationAsync(moonIds);

            Assert.NotNull(moons);
            Assert.Equal(moonIds.Count(), moons.Count());

            foreach (var id in moonIds)
            {
                Assert.Contains(moons, m => m.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForMoonsInAPlanet()
        {
            int planetId = 40139384;
            var moons = await Universe.GetMoonInformationByPlanetAsync(planetId);
            var planet = await Universe.GetPlanetInformationAsync(planetId);

            Assert.NotNull(moons);
            Assert.Equal(planet.Moons.Count(), moons.Count());

            foreach (var id in planet.Moons)
            {
                Assert.Contains(moons, m => m.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForMoonsInPlanets()
        {
            List<int> planetIds = new List<int>() { 40139384, 40009077, 40169266 };
            var moons = await Universe.GetMoonInformationByPlanetAsync(planetIds);
            var planets = await Universe.GetPlanetInformationAsync(planetIds);

            var moonCount = planets.Sum(p => p.Moons.Count);

            Assert.NotNull(moons);
            Assert.Equal(moonCount, moons.Count());

            foreach (var planet in planets)
            {
                foreach (var id in planet.Moons)
                {
                    Assert.Contains(moons, m => m.ID == id);
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForMoonsInASolarSystem()
        {
            int systemId = 30000142;
            var moons = await Universe.GetMoonInformationBySolarSystemAsync(systemId);
            var system = await Universe.GetSolarSystemInformationAsync(systemId);

            var moonCount = system.Planets.Sum(p => p.Moons.Count);

            Assert.NotNull(moons);
            Assert.Equal(moonCount, moons.Count());

            foreach (var planet in system.Planets)
            {
                foreach (var id in planet.Moons)
                {
                    Assert.Contains(moons, m => m.ID == id);
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForMoonsInSolarSystems()
        {
            List<int> systemIds = new List<int>() { 30000142, 30002659, 30002187 };
            var moons = await Universe.GetMoonInformationBySolarSystemAsync(systemIds);
            var systems = await Universe.GetSolarSystemInformationAsync(systemIds);

            var moonCount = 0;
            foreach (var system in systems)
            {
                moonCount += system.Planets.Sum(p => p.Moons.Count);
            }

            Assert.NotNull(moons);
            Assert.Equal(moonCount, moons.Count());

            foreach (var system in systems)
            {
                foreach (var planet in system.Planets)
                {
                    foreach (var id in planet.Moons)
                    {
                        Assert.Contains(moons, m => m.ID == id);
                    }
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForMoonsInAConstellation()
        {
            var constellationId = 20000020;
            var moons = await Universe.GetMoonInformationByConstellationAsync(constellationId);
            var systems = await Universe.GetSolarSystemInformationByConstellationAsync(constellationId);

            var moonCount = 0;
            foreach (var system in systems)
            {
                moonCount += system.Planets.Sum(p => p.Moons.Count);
            }

            Assert.NotNull(moons);
            Assert.Equal(moonCount, moons.Count());

            foreach (var system in systems)
            {
                foreach (var planet in system.Planets)
                {
                    foreach (var id in planet.Moons)
                    {
                        Assert.Contains(moons, m => m.ID == id);
                    }
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForMoonsInConstellations()
        {
            List<int> constellationIds = new List<int>() { 20000020, 20000389, 20000322 };
            var moons = await Universe.GetMoonInformationByConstellationAsync(constellationIds);
            var systems = await Universe.GetSolarSystemInformationByConstellationAsync(constellationIds);

            var moonCount = 0;
            foreach (var system in systems)
            {
                moonCount += system.Planets.Sum(p => p.Moons.Count);
            }

            Assert.NotNull(moons);
            Assert.Equal(moonCount, moons.Count());

            foreach (var system in systems)
            {
                foreach (var planet in system.Planets)
                {
                    foreach (var id in planet.Moons)
                    {
                        Assert.Contains(moons, m => m.ID == id);
                    }
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForMoonsInARegion()
        {
            int regionId = 10000002;
            var moons = await Universe.GetMoonInformationByRegionAsync(regionId);
            var systems = await Universe.GetSolarSystemInformationByRegionAsync(regionId);

            var moonCount = 0;
            foreach (var system in systems)
            {
                moonCount += system.Planets.Sum(p => p.Moons.Count);
            }

            Assert.NotNull(moons);
            Assert.Equal(moonCount, moons.Count());

            foreach (var system in systems)
            {
                foreach (var planet in system.Planets)
                {
                    foreach (var id in planet.Moons)
                    {
                        Assert.Contains(moons, m => m.ID == id);
                    }
                }
            }
        }

        [Fact]
        public async Task CanGetInformationForMoonsInRegions()
        {
            List<int> regionIds = new List<int>() { 10000002, 10000032, 10000043 };
            var moons = await Universe.GetMoonInformationByRegionAsync(regionIds);
            var systems = await Universe.GetSolarSystemInformationByRegionAsync(regionIds);

            var moonCount = 0;
            foreach (var system in systems)
            {
                moonCount += system.Planets.Sum(p => p.Moons.Count);
            }

            Assert.NotNull(moons);
            Assert.Equal(moonCount, moons.Count());

            foreach (var system in systems)
            {
                foreach (var planet in system.Planets)
                {
                    foreach (var id in planet.Moons)
                    {
                        Assert.Contains(moons, m => m.ID == id);
                    }
                }
            }
        }
        #endregion

        #region Asteroid Belt
        [Fact]
        public async Task CanGetInformationForAsteroidBelt()
        {
            int asteroidBeltId = 40139386;
            var asteroidBelt = await Universe.GetAsteroidBeltInformationAsync(asteroidBeltId);

            Assert.NotNull(asteroidBelt);
        }

        [Fact]
        public async Task CanGetInformationForAsteroidBelts()
        {
            List<int> asteroidBeltIds = new List<int>() { 40139386, 40139404, 40139425 };
            var asteroidBelts = await Universe.GetAsteroidBeltInformationAsync(asteroidBeltIds);

            Assert.NotNull(asteroidBelts);
            Assert.Equal(asteroidBeltIds.Count(), asteroidBelts.Count());
        }

        [Fact]
        public async Task CanGetInformationForAsteroidBeltsInAPlanet()
        {
            int planetId = 40139384;
            var asteroidBelts = await Universe.GetAsteroidBeltInformationByPlanetAsync(planetId);
            var planet = await Universe.GetPlanetInformationAsync(planetId);

            Assert.NotNull(asteroidBelts);
            Assert.Equal(planet.AsteroidBelts.Count(), asteroidBelts.Count());

            Assert.All(asteroidBelts, ab => ab.Name.StartsWith(planet.Name + " "));
        }

        [Fact]
        public async Task CanGetInformationForAsteroidBeltsInPlanets()
        {
            List<int> planetIds = new List<int>() { 40139384, 40009077, 40169266 };
            var asteroidBelts = await Universe.GetAsteroidBeltInformationByPlanetAsync(planetIds);
            var planets = await Universe.GetPlanetInformationAsync(planetIds);

            var asteroidBeltCount = planets.Sum(p => p.AsteroidBelts.Count);

            Assert.NotNull(asteroidBelts);
            Assert.Equal(asteroidBeltCount, asteroidBelts.Count());

            foreach (var planet in planets)
            {
                var planetBelts = asteroidBelts.Where(ab => ab.Name.StartsWith(planet.Name + " ")).ToList();
                Assert.Equal(planet.AsteroidBelts.Count, planetBelts.Count);
            }
        }

        [Fact]
        public async Task CanGetInformationForAsteroidBeltsInASolarSystem()
        {
            int systemId = 30000142;
            var asteroidBelts = await Universe.GetAsteroidBeltInformationBySolarSystemAsync(systemId);
            var system = await Universe.GetSolarSystemInformationAsync(systemId);

            var asteroidBeltCount = system.Planets.Sum(p => p.AsteroidBelts.Count);

            Assert.NotNull(asteroidBelts);
            Assert.Equal(asteroidBeltCount, asteroidBelts.Count());

            Assert.All(asteroidBelts, ab => ab.SystemID.Equals(system.ID));
        }

        [Fact]
        public async Task CanGetInformationForAsteroidBeltsInSolarSystems()
        {
            List<int> systemIds = new List<int>() { 30000142, 30002659, 30002187 };
            var asteroidBelts = await Universe.GetAsteroidBeltInformationBySolarSystemAsync(systemIds);
            var systems = await Universe.GetSolarSystemInformationAsync(systemIds);

            var asteroidBeltCount = 0;
            foreach (var system in systems)
            {
                asteroidBeltCount += system.Planets.Sum(p => p.AsteroidBelts.Count);
            }

            Assert.NotNull(asteroidBelts);
            Assert.Equal(asteroidBeltCount, asteroidBelts.Count());

            foreach (var system in systems)
            {
                var systemBelts = asteroidBelts.Where(ab => ab.SystemID == system.ID).ToList();
                var systemBeltCount = system.Planets.Sum(p => p.AsteroidBelts.Count);

                Assert.Equal(systemBeltCount, systemBelts.Count);
            }
        }

        [Fact]
        public async Task CanGetInformationForAsteroidBeltsInAConstellation()
        {
            var constellationId = 20000020;
            var asteroidBelts = await Universe.GetAsteroidBeltInformationByConstellationAsync(constellationId);
            var systems = await Universe.GetSolarSystemInformationByConstellationAsync(constellationId);

            var asteroidBeltCount = 0;
            foreach (var system in systems)
            {
                asteroidBeltCount += system.Planets.Sum(p => p.AsteroidBelts.Count);
            }

            Assert.NotNull(asteroidBelts);
            Assert.Equal(asteroidBeltCount, asteroidBelts.Count());

            foreach (var system in systems)
            {
                var systemBelts = asteroidBelts.Where(ab => ab.SystemID == system.ID).ToList();
                var systemBeltCount = system.Planets.Sum(p => p.AsteroidBelts.Count);

                Assert.Equal(systemBeltCount, systemBelts.Count);
            }
        }

        [Fact]
        public async Task CanGetInformationForAsteroidBeltsInConstellations()
        {
            List<int> constellationIds = new List<int>() { 20000020, 20000389, 20000322 };
            var asteroidBelts = await Universe.GetAsteroidBeltInformationByConstellationAsync(constellationIds);
            var systems = await Universe.GetSolarSystemInformationByConstellationAsync(constellationIds);

            var asteroidBeltCount = 0;
            foreach (var system in systems)
            {
                asteroidBeltCount += system.Planets.Sum(p => p.AsteroidBelts.Count);
            }

            Assert.NotNull(asteroidBelts);
            Assert.Equal(asteroidBeltCount, asteroidBelts.Count());

            foreach (var system in systems)
            {
                var systemBelts = asteroidBelts.Where(ab => ab.SystemID == system.ID).ToList();
                var systemBeltCount = system.Planets.Sum(p => p.AsteroidBelts.Count);

                Assert.Equal(systemBeltCount, systemBelts.Count);
            }
        }

        [Fact]
        public async Task CanGetInformationForAsteroidBeltsInARegion()
        {
            int regionId = 10000002;
            var asteroidBelts = await Universe.GetAsteroidBeltInformationByRegionAsync(regionId);
            var systems = await Universe.GetSolarSystemInformationByRegionAsync(regionId);

            var asteroidBeltCount = 0;
            foreach (var system in systems)
            {
                asteroidBeltCount += system.Planets.Sum(p => p.AsteroidBelts.Count);
            }

            Assert.NotNull(asteroidBelts);
            Assert.Equal(asteroidBeltCount, asteroidBelts.Count());

            foreach (var system in systems)
            {
                var systemBelts = asteroidBelts.Where(ab => ab.SystemID == system.ID).ToList();
                var systemBeltCount = system.Planets.Sum(p => p.AsteroidBelts.Count);

                Assert.Equal(systemBeltCount, systemBelts.Count);
            }
        }

        [Fact]
        public async Task CanGetInformationForAsteroidBeltsInRegions()
        {
            List<int> regionIds = new List<int>() { 10000002, 10000032, 10000043 };
            var asteroidBelts = await Universe.GetAsteroidBeltInformationByRegionAsync(regionIds);
            var systems = await Universe.GetSolarSystemInformationByRegionAsync(regionIds);

            var asteroidBeltCount = 0;
            foreach (var system in systems)
            {
                asteroidBeltCount += system.Planets.Sum(p => p.AsteroidBelts.Count);
            }

            Assert.NotNull(asteroidBelts);
            Assert.Equal(asteroidBeltCount, asteroidBelts.Count());

            foreach (var system in systems)
            {
                var systemBelts = asteroidBelts.Where(ab => ab.SystemID == system.ID).ToList();
                var systemBeltCount = system.Planets.Sum(p => p.AsteroidBelts.Count);

                Assert.Equal(systemBeltCount, systemBelts.Count);
            }
        }
        #endregion
        #endregion

        #region Station/Structure/Stargate
        #region Station
        [Fact]
        public async Task CanGetInformationForStation()
        {
            int stationId = 60002569;
            var station = await Universe.GetStationInformationAsync(stationId);

            Assert.NotNull(station);
            Assert.Equal(stationId, station.ID);
        }

        [Fact]
        public async Task CanGetInformationForStations()
        {
            List<int> stationIds = new List<int>() { 60002569, 60002953, 60011866 };
            var stations = await Universe.GetStationInformationAsync(stationIds);

            Assert.NotNull(stations);
            Assert.Equal(stationIds.Count(), stations.Count());

            foreach(var id in stationIds)
            {
                Assert.Contains(stations, s => s.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForStationsInAMoon()
        {
            int moonId = 40139396;
            var stations = await Universe.GetStationInformationByMoonAsync(moonId);
            var moon = await Universe.GetMoonInformationAsync(moonId);

            Assert.NotNull(stations);
            Assert.All(stations, s => s.Name.StartsWith(moon.Name + " "));
        }

        [Fact]
        public async Task CanGetInformationForStationsInMoons()
        {
            List<int> moonIds = new List<int>() { 40139396, 40009089, 40169269 };
            var stations = await Universe.GetStationInformationByMoonAsync(moonIds);
            var moons = await Universe.GetMoonInformationAsync(moonIds);

            Assert.NotNull(stations);
            Assert.All(stations, s => moons.Any(m => s.Name.StartsWith(m.Name + " ")));
        }

        [Fact]
        public async Task CanGetInformationForStationsInAPlanet()
        {
            int planetId = 40139384;
            var stations = await Universe.GetStationInformationByPlanetAsync(planetId);
            var planet = await Universe.GetPlanetInformationAsync(planetId);

            Assert.NotNull(stations);
            Assert.All(stations, s => s.Name.StartsWith(planet.Name + " "));
        }

        [Fact]
        public async Task CanGetInformationForStationsInPlanets()
        {
            List<int> planetIds = new List<int>() { 40139384, 40009077, 40169266 };
            var stations = await Universe.GetStationInformationByPlanetAsync(planetIds);
            var planets = await Universe.GetPlanetInformationAsync(planetIds);

            Assert.NotNull(stations);
            Assert.All(stations, s => planets.Any(p => s.Name.StartsWith(p.Name + " ")));
        }

        [Fact]
        public async Task CanGetInformationForStationsInASolarSystem()
        {
            int systemId = 30000142;
            var stations = await Universe.GetStationInformationBySolarSystemAsync(systemId);
            var system = await Universe.GetSolarSystemInformationAsync(systemId);

            Assert.NotNull(stations);
            Assert.Equal(system.Stations.Count, stations.Count());

            Assert.All(stations, s => s.SystemID.Equals(system.ID));
        }

        [Fact]
        public async Task CanGetInformationForStationsInSolarSystems()
        {
            List<int> systemIds = new List<int>() { 30000142, 30002659, 30002187 };
            var stations = await Universe.GetStationInformationBySolarSystemAsync(systemIds);
            var systems = await Universe.GetSolarSystemInformationAsync(systemIds);

            var stationCount = systems.Sum(s => s.Stations.Count);

            Assert.NotNull(stations);
            Assert.Equal(stationCount, stations.Count());

            foreach(var system in systems)
            {
                var systemStations = stations.Where(s => s.SystemID == system.ID).ToList();

                Assert.Equal(system.Stations.Count, systemStations.Count);
            }
        }

        [Fact]
        public async Task CanGetInformationForStationsInAConstellation()
        {
            int constellationId = 20000020;
            var stations = await Universe.GetStationInformationByConstellationAsync(constellationId);
            var systems = await Universe.GetSolarSystemInformationByConstellationAsync(constellationId);

            var stationCount = systems.Sum(s => s.Stations.Count);

            Assert.NotNull(stations);
            Assert.Equal(stationCount, stations.Count());

            foreach (var system in systems)
            {
                var systemStations = stations.Where(s => s.SystemID == system.ID).ToList();

                Assert.Equal(system.Stations.Count, systemStations.Count);
            }
        }

        [Fact]
        public async Task CanGetInformationForStationsInConstellations()
        {
            List<int> constellationIds = new List<int>() { 20000020, 20000389, 20000322 };
            var stations = await Universe.GetStationInformationByConstellationAsync(constellationIds);
            var systems = await Universe.GetSolarSystemInformationByConstellationAsync(constellationIds);

            var stationCount = systems.Sum(s => s.Stations.Count);

            Assert.NotNull(stations);
            Assert.Equal(stationCount, stations.Count());

            foreach (var system in systems)
            {
                var systemStations = stations.Where(s => s.SystemID == system.ID).ToList();

                Assert.Equal(system.Stations.Count, systemStations.Count);
            }
        }

        [Fact]
        public async Task CanGetInformationForStationsInARegion()
        {
            var regionId = 10000002;
            var stations = await Universe.GetStationInformationByRegionAsync(regionId);
            var systems = await Universe.GetSolarSystemInformationByRegionAsync(regionId);

            var stationCount = systems.Sum(s => s.Stations.Count);

            Assert.NotNull(stations);
            Assert.Equal(stationCount, stations.Count());

            foreach (var system in systems)
            {
                var systemStations = stations.Where(s => s.SystemID == system.ID).ToList();

                Assert.Equal(system.Stations.Count, systemStations.Count);
            }
        }

        [Fact]
        public async Task CanGetInformationForStationsInRegions()
        {
            List<int> regionIds = new List<int>() { 10000002, 10000032, 10000043 };
            var stations = await Universe.GetStationInformationByRegionAsync(regionIds);
            var systems = await Universe.GetSolarSystemInformationByRegionAsync(regionIds);

            var stationCount = systems.Sum(s => s.Stations.Count);

            Assert.NotNull(stations);
            Assert.Equal(stationCount, stations.Count());

            foreach (var system in systems)
            {
                var systemStations = stations.Where(s => s.SystemID == system.ID).ToList();

                Assert.Equal(system.Stations.Count, systemStations.Count);
            }
        }
        #endregion

        #region Structure
        [Fact]
        public async Task GettingAllPublicStructuresIsNotNullOrEmpty()
        {
            var structures = await Universe.ListAllPublicStructuresAsync();
            Assert.NotNull(structures);
            Assert.NotEmpty(structures);
        }

        [Fact]
        public async Task CanGetInformationForStructure()
        {
            long structureId = 1023126135158;
            var structure = await Universe.GetStructureInformationAsync(structureId);

            Assert.NotNull(structure);
        }

        [Fact]
        public async Task CanGetInformationForStructures()
        {
            List<long> structureIds = new List<long>() { 1023126135158, 1027436601364, 1026466808012 };
            var structures = await Universe.GetStructureInformationAsync(structureIds);

            Assert.NotNull(structures);
            Assert.Equal(structureIds.Count, structures.Count());
        }
        #endregion

        #region Stargate
        [Fact]
        public async Task CanGetInformationForStargate()
        {
            int stargateId = 50001250;
            var stargate = await Universe.GetStargateInformationAsync(stargateId);

            Assert.NotNull(stargate);
            Assert.Equal(stargateId, stargate.ID);
        }

        [Fact]
        public async Task CanGetInformationForStargates()
        {
            List<int> stargateIds = new List<int>() { 50001250, 50007873, 50013733 };
            var stargates = await Universe.GetStargateInformationAsync(stargateIds);

            Assert.NotNull(stargates);
            Assert.Equal(stargateIds.Count(), stargates.Count());

            foreach (var id in stargateIds)
            {
                Assert.Contains(stargates, s => s.ID == id);
            }
        }

        [Fact]
        public async Task CanGetInformationForStargatesInASolarSystem()
        {
            int systemId = 30000142;
            var stargates = await Universe.GetStargateInformationBySolarSystemAsync(systemId);
            var system = await Universe.GetSolarSystemInformationAsync(systemId);

            Assert.NotNull(stargates);
            Assert.Equal(system.Stargates.Count, stargates.Count());

            Assert.All(stargates, s => s.SystemID.Equals(system.ID));
        }

        [Fact]
        public async Task CanGetInformationForStargatesInSolarSystems()
        {
            List<int> systemIds = new List<int>() { 30000142, 30002659, 30002187 };
            var stargates = await Universe.GetStargateInformationBySolarSystemAsync(systemIds);
            var systems = await Universe.GetSolarSystemInformationAsync(systemIds);

            var stargateCount = systems.Sum(s => s.Stargates.Count);

            Assert.NotNull(stargates);
            Assert.Equal(stargateCount, stargates.Count());

            foreach (var system in systems)
            {
                var systemStargates = stargates.Where(s => s.SystemID == system.ID).ToList();

                Assert.Equal(system.Stargates.Count, systemStargates.Count);
            }
        }

        [Fact]
        public async Task CanGetInformationForStargatesInAConstellation()
        {
            int constellationId = 20000020;
            var stargates = await Universe.GetStargateInformationByConstellationAsync(constellationId);
            var systems = await Universe.GetSolarSystemInformationByConstellationAsync(constellationId);

            var stargateCount = systems.Sum(s => s.Stargates.Count);

            Assert.NotNull(stargates);
            Assert.Equal(stargateCount, stargates.Count());

            foreach (var system in systems)
            {
                var systemStargates = stargates.Where(s => s.SystemID == system.ID).ToList();

                Assert.Equal(system.Stargates.Count, systemStargates.Count);
            }
        }

        [Fact]
        public async Task CanGetInformationForStargatesInConstellations()
        {
            List<int> constellationIds = new List<int>() { 20000020, 20000389, 20000322 };
            var stargates = await Universe.GetStargateInformationByConstellationAsync(constellationIds);
            var systems = await Universe.GetSolarSystemInformationByConstellationAsync(constellationIds);

            var stargateCount = systems.Sum(s => s.Stargates.Count);

            Assert.NotNull(stargates);
            Assert.Equal(stargateCount, stargates.Count());

            foreach (var system in systems)
            {
                var systemStargates = stargates.Where(s => s.SystemID == system.ID).ToList();

                Assert.Equal(system.Stargates.Count, systemStargates.Count);
            }
        }

        [Fact]
        public async Task CanGetInformationForStargatesInARegion()
        {
            var regionId = 10000002;
            var stargates = await Universe.GetStargateInformationByRegionAsync(regionId);
            var systems = await Universe.GetSolarSystemInformationByRegionAsync(regionId);

            var stargateCount = systems.Sum(s => s.Stargates.Count);

            Assert.NotNull(stargates);
            Assert.Equal(stargateCount, stargates.Count());

            foreach (var system in systems)
            {
                var systemStargates = stargates.Where(s => s.SystemID == system.ID).ToList();

                Assert.Equal(system.Stargates.Count, systemStargates.Count);
            }
        }

        [Fact]
        public async Task CanGetInformationForStargatesInRegions()
        {
            List<int> regionIds = new List<int>() { 10000002, 10000032, 10000043 };
            var stargates = await Universe.GetStargateInformationByRegionAsync(regionIds);
            var systems = await Universe.GetSolarSystemInformationByRegionAsync(regionIds);

            var stargateCount = systems.Sum(s => s.Stargates.Count);

            Assert.NotNull(stargates);
            Assert.Equal(stargateCount, stargates.Count());

            foreach (var system in systems)
            {
                var systemStargates = stargates.Where(s => s.SystemID == system.ID).ToList();

                Assert.Equal(system.Stargates.Count, systemStargates.Count);
            }
        }
        #endregion
        #endregion
    }
}
