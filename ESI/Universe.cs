namespace ESI
{
    /// <summary>
    /// Universe ESI urls
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
    }
}
