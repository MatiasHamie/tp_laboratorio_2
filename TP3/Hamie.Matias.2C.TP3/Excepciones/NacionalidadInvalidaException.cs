﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    class NacionalidadInvalidaException:Exception
    {
        public NacionalidadInvalidaException()
            : this("Nacionalidad inválida") { }

        public NacionalidadInvalidaException(string message)
            : base(message) { }

    }
}