 
ŽC:\Users\rowan\Desktop\Tools\School\Semester 3\Ip\GamifyWork\Application\Backend\GamifyWork\src\GamifyWork.DataAccessLibrary\Data\dbContext.cs
	namespace

 	

GamifyWork


 
.

 
DataAccessLibrary

 &
.

& '
Data

' +
{ 
public 

class 
	dbContext 
: 
	DbContext &
{ 
private 
readonly 
string 
_connectionString  1
;1 2
public 
	dbContext 
( 
IConfiguration '
configuration( 5
)5 6
{ 	
_connectionString 
= 
configuration  -
.- .
GetConnectionString. A
(A B
$strB U
)U V
;V W
} 	
	protected 
override 
void 
OnConfiguring  -
(- .#
DbContextOptionsBuilder. E#
dbContextOptionsBuilderF ]
)] ^
=>_ a#
dbContextOptionsBuilder #
.# $
UseMySQL$ ,
(, -
_connectionString- >
)> ?
;? @
public 
DbSet 
< 
	TaskModel 
> 
task  $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} ¯

›C:\Users\rowan\Desktop\Tools\School\Semester 3\Ip\GamifyWork\Application\Backend\GamifyWork\src\GamifyWork.DataAccessLibrary\Repositories\TaskRepository.cs
	namespace 	

GamifyWork
 
. 
DataAccessLibrary &
.& '
Repositories' 3
{ 
public 

class 
TaskRepository 
:  !
ITaskRepository" 1
{ 
private 
readonly 
	dbContext "

_dbContext# -
;- .
public 
TaskRepository 
( 
	dbContext '
	dbContext( 1
)1 2
{ 	

_dbContext 
= 
	dbContext #
;# $
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
	TaskModel& /
>/ 0
>0 1
GetAllTasks2 =
(= >
)> ?
{ 	
using 
( 

_dbContext 
) 
{ 
return 
await 

_dbContext '
.' (
task( ,
., -
ToListAsync- 8
(8 9
)9 :
;: ;
} 
} 	
} 
} 