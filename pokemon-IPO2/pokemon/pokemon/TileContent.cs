using System;
using Windows.Data.Xml.Dom;

namespace pokemon
{
    internal class TileContent
    {
        public TileVisual Visual { get; internal set; }

        internal XmlDocument GetXml()
        {
            throw new NotImplementedException();
        }
    }
}