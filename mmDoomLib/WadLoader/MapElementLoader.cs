using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mmDoomLibOld
{

    public class MapElementLoader : BaseElementLoader
    {

        public override int CanLoad(BinaryReader reader, IList<DirectoryEntry> entries)
        {

            // The first lump in a map is always a blank marker entry. If the
            // first entry isn't blank, it's not a map.
            if (entries[0].Size != 0)
                return 0;

            // Define essential entries.
            List<string> essentialEntries = new List<string>(
                new string[] { "THINGS", "LINEDEFS", "SIDEDEFS", "VERTEXES", "SECTORS" }
            );

            // Define optional entries.
            List<string> optionalEntries = new List<string>(
                new string[] { "SEGS", "SSECTORS", "NODES", "REJECT", "BLOCKMAP" }
            );

            // Go through the entries until we run out of map entries.
            int index = 1;
            while (index < entries.Count)
            {

                // Attempt to find the current entry inside the essential entry
                // list.
                int entryIndex = essentialEntries.FindIndex(lump => lump == entries[index].Name);
                if (entryIndex > -1)
                {
                    essentialEntries.RemoveAt(entryIndex);
                    index++;
                    continue;
                }

                // Attempt to find the current entry inside the optional entry
                // list.
                entryIndex = optionalEntries.FindIndex(lump => lump == entries[index].Name);
                if (entryIndex > -1)
                {
                    optionalEntries.RemoveAt(entryIndex);
                    index++;
                    continue;
                }

                // We have reached the end of the map entries, break out of the
                // loop.
                break;

            }

            // If we have cleared all essential entries, this is a map.
            if (essentialEntries.Count == 0)
                return index;

            // Otherwise, this is not a map.
            return 0;

        }

        public override IElement Load(BinaryReader reader, IList<DirectoryEntry> entries)
        {

            // Create the map.
            MapElement map = new MapElement(entries[0].Name);

            // Iterate through the remaining entries and construct appropriate
            // data for each one.
            foreach (DirectoryEntry entry in entries)
            {

                // Set the reader's position.
                reader.BaseStream.Position = entry.Offset;

                // Load the data into the map.
                switch(entry.Name)
                {

                    case "THINGS":
                        map.Things = LoadThings(reader, entry);
                        break;

                    case "LINEDEFS":
                        map.LineDef = LoadLines(reader, entry);
                        break;

                    case "SIDEDEFS":
                        map.SideDef = LoadSides(reader, entry);
                        break;

                    case "VERTEXES":
                        map.Vertexes = LoadVertexes(reader, entry);
                        break;

                    case "SEGS":
                        map.Segments = reader.ReadBytes(entry.Size);
                        break;

                    case "SSECTORS":
                        map.SubSectors = reader.ReadBytes(entry.Size);
                        break;

                    case "NODES":
                        map.Nodes = reader.ReadBytes(entry.Size);
                        break;

                    case "SECTORS":
                        map.Sectors = LoadSectors(reader, entry);
                        break;

                    case "REJECT":
                        map.RejectTable = reader.ReadBytes(entry.Size);
                        break;

                    case "BLOCKMAP":
                        map.Blockmap = reader.ReadBytes(entry.Size);
                        break;

                }

            }

            // Return the complete map.
            return map;

        }

        /// <summary>
        /// Loads things from the file.
        /// </summary>
        /// <param name="reader">The file reader.</param>
        /// <param name="entry">The entry.</param>
        /// <returns>A list of things.</returns>
        private IList<MapThing> LoadThings(BinaryReader reader, DirectoryEntry entry)
        {

            // Prepare the list.
            IList<MapThing> things = new List<MapThing>();

            // Add each thing, one at a time.
            while (reader.BaseStream.Position < entry.Offset + entry.Size)
            {

                // Create the thing.
                MapThing thing = new MapThing();
                thing.X = reader.ReadInt16();
                thing.Y = reader.ReadInt16();
                thing.Angle = reader.ReadUInt16();
                thing.Type = reader.ReadUInt16();
                thing.Flags = reader.ReadUInt16();

                // Add the thing to the list.
                things.Add(thing);

            }

            // Return the list.
            return things;

        }

        /// <summary>
        /// Loads lines from the file.
        /// </summary>
        /// <param name="reader">The file reader.</param>
        /// <param name="entry">The entry.</param>
        /// <returns>A list of lines.</returns>
        private IList<MapLineDefs> LoadLines(BinaryReader reader, DirectoryEntry entry)
        {
            int junk = 0;
            // Prepare the list.
            IList<MapLineDefs> lines = new List<MapLineDefs>();

            // Add each line, one at a time. (I'm a poet and didn't know it!)
            while (reader.BaseStream.Position < entry.Offset + entry.Size)
            {

                // Create the line.
                MapLineDefs line = new MapLineDefs();
                line.StartVertex = reader.ReadUInt16();
                line.EndVertex = reader.ReadUInt16();
                line.Flags = reader.ReadUInt16();
                line.Action = reader.ReadUInt16();
                line.Tag = reader.ReadUInt16();

                line.RightSide = reader.ReadUInt16();
                if (line.RightSide == UInt16.MaxValue)
                    line.RightSide = 0;

                line.LeftSide = reader.ReadUInt16();
                if (line.LeftSide == UInt16.MaxValue)
                    line.LeftSide = 0;
                // Add the line to the list.
                lines.Add(line);

            }

            // Return the list.
            return lines;

        }

        /// <summary>
        /// Loads sides from the file.
        /// </summary>
        /// <param name="reader">The file reader.</param>
        /// <param name="entry">The entry.</param>
        /// <returns>A list of sides.</returns>
        private IList<MapSideDefs> LoadSides(BinaryReader reader, DirectoryEntry entry)
        {

            // Prepare the list.
            IList<MapSideDefs> sides = new List<MapSideDefs>();

            // Add each side, one at a time.
            while (reader.BaseStream.Position < entry.Offset + entry.Size)
            {

                // Create the side.
                MapSideDefs side = new MapSideDefs();
                side.XOffset = reader.ReadInt16();
                side.YOffset = reader.ReadInt16();
                side.UpperTexture = FormatString(reader.ReadChars(8));
                side.LowerTexture = FormatString(reader.ReadChars(8));
                side.MiddleTexture = FormatString(reader.ReadChars(8));
                side.Sector = reader.ReadUInt16();

                // Add the side to the list.
                sides.Add(side);

            }

            // Return the list.
            return sides;

        }

        /// <summary>
        /// Loads vertexes from the file.
        /// </summary>
        /// <param name="reader">The file reader.</param>
        /// <param name="entry">The entry.</param>
        /// <returns>A list of vertexes.</returns>
        private IList<MapVertex> LoadVertexes(BinaryReader reader, DirectoryEntry entry)
        {

            // Prepare the list.
            IList<MapVertex> vertexes = new List<MapVertex>();

            // Add each vertex, one at a time.
            while (reader.BaseStream.Position < entry.Offset + entry.Size)
            {

                // Create the vertex.
                MapVertex vertex = new MapVertex();
                vertex.X = reader.ReadInt16();
                vertex.Y = reader.ReadInt16();

                // Add the vertex to the list.
                vertexes.Add(vertex);

            }

            // Return the list.
            return vertexes;

        }

        /// <summary>
        /// Loads sectors from the file.
        /// </summary>
        /// <param name="reader">The file reader.</param>
        /// <param name="entry">The entry.</param>
        /// <returns>A list of sectors.</returns>
        private IList<MapSector> LoadSectors(BinaryReader reader, DirectoryEntry entry)
        {

            // Prepare the list.
            IList<MapSector> sectors = new List<MapSector>();

            // Add each sector, one at a time.
            while (reader.BaseStream.Position < entry.Offset + entry.Size)
            {

                // Create the sector.
                MapSector sector = new MapSector();
                sector.FloorHeight = reader.ReadInt16();
                sector.CeilingHeight = reader.ReadInt16();
                sector.FloorTexture = FormatString(reader.ReadChars(8));
                sector.CeilingTexture = FormatString(reader.ReadChars(8));
                sector.Light = reader.ReadInt16();
                sector.Action = reader.ReadUInt16();
                sector.Tag = reader.ReadUInt16();

                // Add the sector to the list.
                sectors.Add(sector);

            }

            // Return the list.
            return sectors;

        }

    }

}