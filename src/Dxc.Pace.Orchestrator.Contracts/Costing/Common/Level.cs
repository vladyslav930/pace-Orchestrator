using System;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.Common
{
    public class Level
    {
        public int LevelType { get; set; }

        public Guid LevelId { get; set; }

        public Level(int levelType, Guid levelId)
        {
            LevelType = levelType;
            LevelId = levelId;
        }

        public static Level[] Create(int levelType, Guid levelId)
        {
            return new[] { new Level(levelType, levelId) };
        }
    }
}