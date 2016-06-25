using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payday2InvEdit
{
    class Itemek
    {
        private String _itemHexId;
        private int _itemQty;
        private String _itemOther;

        public string ItemHexId
        {
            get
            {
                return _itemHexId;
            }

            set
            {
                _itemHexId = value;
            }
        }

        public int ItemQty
        {
            get
            {
                return _itemQty;
            }

            set
            {
                _itemQty = value;
            }
        }

        public string ItemOther
        {
            get
            {
                return _itemOther;
            }

            set
            {
                _itemOther = value;
            }
        }

        public Itemek(String itemHID, int itemQ, String itemO)
        {
            _itemHexId = itemHID;
            _itemQty = itemQ;
            _itemOther = itemO;
        }
    }
}
