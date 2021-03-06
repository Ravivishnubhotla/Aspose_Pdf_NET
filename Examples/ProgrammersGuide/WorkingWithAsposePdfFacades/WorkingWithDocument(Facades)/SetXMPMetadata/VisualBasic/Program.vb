'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Pdf. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Pdf
Imports Aspose.Pdf.Facades

Namespace SetXMPMetadataExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'create PdfXmpMetadata object
			Dim xmpMetaData As New PdfXmpMetadata()

			'bind pdf file to the object
			xmpMetaData.BindPdf(dataDir & "input.pdf")

			'add create date
			xmpMetaData.Add(DefaultMetadataProperties.CreateDate, System.DateTime.Now.ToString())

			'change meta data date
			xmpMetaData(DefaultMetadataProperties.MetadataDate) = System.DateTime.Now.ToString()

			'add creator tool
			xmpMetaData.Add(DefaultMetadataProperties.CreatorTool, "Creator tool name")

			'remove modify date
			xmpMetaData.Remove(DefaultMetadataProperties.ModifyDate)

			'add user defined property
			'step #1: register namespace prefix and URI
			xmpMetaData.RegisterNamespaceURI("customNamespace", "http://www.customNameSpaces.com/ns/")
			'step #2: add user property with the prefix
			xmpMetaData.Add("customNamespace:UserPropertyName", "UserPropertyValue")

			'change user defined property
			xmpMetaData("customNamespace:UserPropertyName") = "UserPropertyValue2"

			'save xmp meta data in the pdf file
			xmpMetaData.Save(dataDir & "output.pdf")

			'close the object
			xmpMetaData.Close()

		End Sub
	End Class
End Namespace