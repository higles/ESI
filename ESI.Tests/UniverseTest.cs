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

        #region Region/Constellation/System/Star/Planet/Moon
        #region Region

        #endregion

        #region Constellation

        #endregion

        #region System

        #endregion

        #region Star

        #endregion

        #region Planet

        #endregion

        #region Moon

        #endregion
        #endregion

        #region Station/Structure/Stargate
        #region Station

        #endregion

        #region Structure

        #endregion

        #region Stargate

        #endregion
        #endregion
    }
}
