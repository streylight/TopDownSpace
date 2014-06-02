TopDownSpace
============

<del>SubSpace clone</del>
New IP: Sandbox indie puzzle platformer with zombie survival and local multiplayer. Quirky inside jokes illustrated in beautiful 8 bit pixel art hidden in all 30 levels. First 10 levels are free; The other 20 can be purchased in-game. Also, Fun DLC including pets, hats, etc. Season pass avaliable.


<?xml version="1.0" encoding="utf-8" ?>
<!-- SQL XML created by WWW SQL Designer, http://code.google.com/p/wwwsqldesigner/ -->
<!-- Active URL: http://ondras.zarovi.cz/sql/demo/ -->
<sql>
<datatypes db="mysql">
	<group label="Numeric" color="rgb(238,238,170)">
		<type label="Integer" length="0" sql="INTEGER" quote=""/>
	 	<type label="TINYINT" length="0" sql="TINYINT" quote=""/>
	 	<type label="SMALLINT" length="0" sql="SMALLINT" quote=""/>
	 	<type label="MEDIUMINT" length="0" sql="MEDIUMINT" quote=""/>
	 	<type label="INT" length="0" sql="INT" quote=""/>
		<type label="BIGINT" length="0" sql="BIGINT" quote=""/>
		<type label="Decimal" length="1" sql="DECIMAL" re="DEC" quote=""/>
		<type label="Single precision" length="0" sql="FLOAT" quote=""/>
		<type label="Double precision" length="0" sql="DOUBLE" re="DOUBLE" quote=""/>
	</group>

	<group label="Character" color="rgb(255,200,200)">
		<type label="Char" length="1" sql="CHAR" quote="'"/>
		<type label="Varchar" length="1" sql="VARCHAR" quote="'"/>
		<type label="Text" length="0" sql="MEDIUMTEXT" re="TEXT" quote="'"/>
		<type label="Binary" length="1" sql="BINARY" quote="'"/>
		<type label="Varbinary" length="1" sql="VARBINARY" quote="'"/>
		<type label="BLOB" length="0" sql="BLOB" re="BLOB" quote="'"/>
	</group>

	<group label="Date &amp; Time" color="rgb(200,255,200)">
		<type label="Date" length="0" sql="DATE" quote="'"/>
		<type label="Time" length="0" sql="TIME" quote="'"/>
		<type label="Datetime" length="0" sql="DATETIME" quote="'"/>
		<type label="Year" length="0" sql="YEAR" quote=""/>
		<type label="Timestamp" length="0" sql="TIMESTAMP" quote="'"/>
	</group>
	
	<group label="Miscellaneous" color="rgb(200,200,255)">
		<type label="ENUM" length="1" sql="ENUM" quote=""/>
		<type label="SET" length="1" sql="SET" quote=""/>
		<type label="Bit" length="0" sql="bit" quote=""/>
	</group>
</datatypes><table x="458" y="166" name="Video">
<row name="Id" null="0" autoincrement="1">
<datatype>INTEGER</datatype>
<default>NULL</default></row>
<row name="Title" null="0" autoincrement="0">
<datatype>VARCHAR(256)</datatype>
<default>'NULL'</default></row>
<row name="Description" null="0" autoincrement="0">
<datatype>VARCHAR</datatype>
<default>'NULL'</default></row>
<row name="TagId" null="0" autoincrement="0">
<datatype>INTEGER</datatype>
<default>NULL</default></row>
<row name="ByteSize" null="1" autoincrement="0">
<datatype>INTEGER</datatype>
<default>NULL</default></row>
<row name="Difficulty" null="1" autoincrement="0">
<datatype>VARCHAR</datatype>
<default>NULL</default></row>
<row name="CourseId" null="1" autoincrement="0">
<datatype>INTEGER</datatype>
<default>NULL</default><relation table="Course" row="Id" />
</row>
<key type="PRIMARY" name="">
<part>Id</part>
</key>
</table>
<table x="1031" y="221" name="Tag">
<row name="Id" null="0" autoincrement="1">
<datatype>INTEGER</datatype>
<default>NULL</default></row>
<row name="Name" null="0" autoincrement="0">
<datatype>VARCHAR(256)</datatype>
<default>'NULL'</default></row>
<key type="PRIMARY" name="">
<part>Id</part>
</key>
</table>
<table x="211" y="295" name="Course">
<row name="Id" null="0" autoincrement="1">
<datatype>INTEGER</datatype>
<default>NULL</default></row>
<row name="Name" null="0" autoincrement="0">
<datatype>VARCHAR(256)</datatype>
<default>'NULL'</default></row>
<row name="Category" null="0" autoincrement="0">
<datatype>VARCHAR(256)</datatype>
<default>'NULL'</default></row>
<row name="VideoCount" null="1" autoincrement="0">
<datatype>INTEGER</datatype>
<default>NULL</default></row>
<key type="PRIMARY" name="">
<part>Id</part>
</key>
</table>
<table x="668" y="149" name="VideoToTagMap">
<row name="Id" null="1" autoincrement="1">
<datatype>INTEGER</datatype>
<default>NULL</default></row>
<row name="VideoId" null="0" autoincrement="0">
<datatype>INTEGER</datatype>
<default>NULL</default><relation table="Video" row="Id" />
</row>
<row name="TagId" null="0" autoincrement="0">
<datatype>INTEGER</datatype>
<default>NULL</default><relation table="Tag" row="Id" />
</row>
<key type="PRIMARY" name="">
<part>Id</part>
</key>
</table>
<table x="401" y="566" name="CourseReport">
<row name="Id" null="1" autoincrement="1">
<datatype>INTEGER</datatype>
<default>NULL</default></row>
<row name="NumberOfCoursesTaken" null="1" autoincrement="0">
<datatype>INTEGER</datatype>
<default>NULL</default></row>
<row name="Completed" null="1" autoincrement="0">
<datatype>INTEGER</datatype>
<default>NULL</default></row>
<row name="Incomplete" null="1" autoincrement="0">
<datatype>INTEGER</datatype>
<default>NULL</default></row>
<key type="PRIMARY" name="">
<part>Id</part>
</key>
</table>
</sql>
