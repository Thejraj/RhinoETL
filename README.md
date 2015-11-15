# RhinoETL
ETL process in C#.Net equivalent for SSIS package

Create easy ETL process through Rhino using c#.net. 
Rhino ETL library provide flexibility to extract data from different type of source such as txt file, csv file, database etc.
Also transform data and store in expected destinations such as file, database etc.

A quick demo with simple approach for Rhino ETL

ImportFiles: EtlProcess
Act as controller to delegate action to appropriate operations

DataRecord
Define data delimiter

JoinWordLists: JoinOperation
Define primary key from different source files to combine the data. Implemented on JoinOperation base class.

PutData : AbstractOperation
Provide transfered data

SimpleFileDataGet : AbstractOperation
Get data from defined file
