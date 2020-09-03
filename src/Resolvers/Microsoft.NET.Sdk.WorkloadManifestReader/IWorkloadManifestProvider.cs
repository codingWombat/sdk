﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Net.Sdk.WorkloadManifestReader
{
    /// <summary>
    /// This abstracts out the process of locating and loading a set of manifests to be loaded into a
    /// workload manifest resolver and resolved into a single coherent model.
    /// </summary>
    public interface IWorkloadManifestProvider
    {
        IEnumerable<Stream> GetManifests();
    }
}
