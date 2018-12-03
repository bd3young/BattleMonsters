using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleMonsters
{
    class BattleMonster
    {

        public enum Element
        {
            GRASS,
            WATER,
            FIRE,
            LIGHT,
            DARK
        }

        public enum Size
        {
            SMALL,
            MEDIUM,
            LARGE
        }
        #region FIELDS

        private string _name;
        private Element _monsterElement;
        private Size _monsterSize;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Element monsterElement
        {
            get { return _monsterElement; }
            set { _monsterElement = value; }
        }

        public Size monsterSize
        {
            get { return _monsterSize; }
            set { _monsterSize = value; }
        }

        #endregion

        #region CONSTRUCTORS



        #endregion

        #region METHODS

        public string EnemyBattleMonsters()
        {
            return _name + " is a " + _monsterSize + " monster with the element of " + _monsterElement + ".";
        }

        #endregion
    }
}
