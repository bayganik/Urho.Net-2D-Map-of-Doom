﻿//
// Copyright (C) 1993-1996 Id Software, Inc.
// Copyright (C) 2019-2020 Nobuaki Tanaka
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//



using System;

namespace mmDoomLib
{
    public sealed class DivLine
    {
        private Fixed x;
        private Fixed y;
        private Fixed dx;
        private Fixed dy;

        public void MakeFrom(LineDef line)
        {
            x = line.Vertex1.X;
            y = line.Vertex1.Y;
            dx = line.Dx;
            dy = line.Dy;
        }

        public Fixed X
        {
            get => x;
            set => x = value;
        }

        public Fixed Y
        {
            get => y;
            set => y = value;
        }

        public Fixed Dx
        {
            get => dx;
            set => dx = value;
        }

        public Fixed Dy
        {
            get => dy;
            set => dy = value;
        }
    }
}