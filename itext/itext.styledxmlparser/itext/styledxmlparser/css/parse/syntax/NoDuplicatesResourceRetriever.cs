/*
This file is part of the iText (R) project.
Copyright (c) 1998-2024 Apryse Group NV
Authors: Apryse Software.

This program is offered under a commercial and under the AGPL license.
For commercial licensing, contact us at https://itextpdf.com/sales.  For AGPL licensing, see below.

AGPL licensing:
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.IO;
using iText.StyledXmlParser.Resolver.Resource;

namespace iText.StyledXmlParser.Css.Parse.Syntax {
//\cond DO_NOT_DOCUMENT
    /// <summary>
    /// Implementation of
    /// <see cref="iText.StyledXmlParser.Resolver.Resource.DefaultResourceRetriever"/>
    /// which returns
    /// <see langword="null"/>
    /// if the
    /// <c>URL</c>
    /// from
    /// <see cref="GetInputStreamByUrl(System.Uri)"/>
    /// has been already processed by the current instance.
    /// </summary>
    internal class NoDuplicatesResourceRetriever : DefaultResourceRetriever {
        private readonly ICollection<String> processedUrls = new HashSet<String>();

//\cond DO_NOT_DOCUMENT
        /// <summary>
        /// Creates a new
        /// <see cref="NoDuplicatesResourceRetriever"/>
        /// instance.
        /// </summary>
        internal NoDuplicatesResourceRetriever()
            : base() {
        }
//\endcond

        public override Stream GetInputStreamByUrl(Uri url) {
            if (processedUrls.Contains(url.ToExternalForm())) {
                return null;
            }
            processedUrls.Add(url.ToExternalForm());
            return base.GetInputStreamByUrl(url);
        }
    }
//\endcond
}
