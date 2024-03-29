﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Untold
{
    public class Player
    {
        public World World { get; }

        [JsonIgnore]
        public Room Location { get; private set; }

        [JsonIgnore]
        public int Moves { get; set; }

        [JsonIgnore]
        public int Score { get; set; }

        public string LocationName
        {
            get
            {
                return Location?.Name;
            }
            set
            {
                Location = World?.RoomsByName.GetValueOrDefault(value);
            }
        }

        public Player(World world, string startingLocation)
        {
            World = world;
            LocationName = startingLocation;
        }
        
        public bool Move(Directions direction)
        {
            bool isValidMove = Location.Neighbors.TryGetValue(direction, out Room destination);
            if (isValidMove)
            {
                Location = destination;
            }

            return isValidMove;
        }

        public Dictionary<string, Item> Inventory { get; private set; } = new Dictionary<string, Item>();
    }
}