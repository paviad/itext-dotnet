/*
This file is part of the iText (R) project.
Copyright (c) 1998-2020 iText Group NV
Authors: iText Software.

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
using iText.IO.Source;
using iText.Kernel;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Exceptions;
using iText.Test;

namespace iText.Layout {
    public class DocumentTest : ExtendedITextTest {
        [NUnit.Framework.Test]
        public virtual void ExecuteActionInClosedDocTest() {
            NUnit.Framework.Assert.That(() =>  {
                PdfDocument pdfDoc = new PdfDocument(new PdfWriter(new ByteArrayOutputStream()));
                Document document = new Document(pdfDoc);
                Paragraph paragraph = new Paragraph("test");
                document.Add(paragraph);
                document.Close();
                document.CheckClosingStatus();
            }
            , NUnit.Framework.Throws.InstanceOf<PdfException>().With.Message.EqualTo(LayoutExceptionMessageConstant.DOCUMENT_CLOSED_IT_IS_IMPOSSIBLE_TO_EXECUTE_ACTION))
;
        }
    }
}