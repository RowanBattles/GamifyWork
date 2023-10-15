›
óC:\Users\rowan\Desktop\Tools\School\Semester 3\Ip\GamifyWork\Application\Backend\GamifyWork\src\GamifyWork.ServiceLibrary\Interfaces\ITaskRepository.cs
	namespace 	

GamifyWork
 
. 
ServiceLibrary #
.# $

Interfaces$ .
{		 
public

 

	interface

 
ITaskRepository

 $
{ 
Task 
< 
IEnumerable 
< 
	TaskModel "
>" #
># $
GetAllTasks% 0
(0 1
)1 2
;2 3
} 
} ¢
îC:\Users\rowan\Desktop\Tools\School\Semester 3\Ip\GamifyWork\Application\Backend\GamifyWork\src\GamifyWork.ServiceLibrary\Interfaces\ITaskService.cs
	namespace 	

GamifyWork
 
. 
ServiceLibrary #
.# $

Interfaces$ .
{		 
public

 

	interface

 
ITaskService

 !
{ 
Task 
< 
IEnumerable 
> 
GetAllTasks %
(% &
)& '
;' (
} 
} › 
çC:\Users\rowan\Desktop\Tools\School\Semester 3\Ip\GamifyWork\Application\Backend\GamifyWork\src\GamifyWork.ServiceLibrary\Models\TaskModel.cs
	namespace		 	

GamifyWork		
 
.		 
ServiceLibrary		 #
.		# $
Models		$ *
{

 
public 

class 
	TaskModel 
{ 
public 
	TaskModel 
( 
int 
task_ID $
,$ %
string& ,
title- 2
,2 3
string4 :
?: ;
description< G
,G H
intI L
?L M
pointsN T
,T U
boolV Z
	completed[ d
,d e
bool 
	recurring 
, 
string "
?" #
recurrenceType$ 2
,2 3
int4 7
?7 8
recurrenceInterval9 K
,K L
DateTimeM U
?U V
nextDueDateW b
,b c
intd g
user_IDh o
)o p
{ 	
Task_ID 
= 
task_ID 
; 
Title 
= 
title 
; 
Description 
= 
description %
;% &
Points 
= 
points 
; 
	Completed 
= 
	completed !
;! "
RecurrenceType 
= 
recurrenceType +
;+ ,
RecurrenceInterval 
=  
recurrenceInterval! 3
;3 4
NextDueDate 
= 
nextDueDate %
;% &
User_ID 
= 
user_ID 
; 
} 	
[ 	
Key	 
] 
[ 	
DatabaseGenerated	 
( #
DatabaseGeneratedOption 2
.2 3
Identity3 ;
); <
]< =
public 
int 
Task_ID 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
Required	 
] 
[   	
StringLength  	 
(   
$num   
)   
]   
public!! 
string!! 
Title!! 
{!! 
get!! !
;!!! "
set!!# &
;!!& '
}!!( )
[## 	
StringLength##	 
(## 
$num## 
)## 
]## 
public$$ 
string$$ 
?$$ 
Description$$ "
{$$# $
get$$% (
;$$( )
set$$* -
;$$- .
}$$/ 0
public'' 
int'' 
?'' 
Points'' 
{'' 
get''  
;''  !
set''" %
;''% &
}''' (
[)) 	
Required))	 
])) 
public** 
bool** 
	Completed** 
{** 
get**  #
;**# $
set**% (
;**( )
}*** +
[,, 	
Required,,	 
],, 
public-- 
bool-- 
	Recurring-- 
{-- 
get--  #
;--# $
set--% (
;--( )
}--* +
[// 	
StringLength//	 
(// 
$num// 
)// 
]// 
public00 
string00 
?00 
RecurrenceType00 %
{00& '
get00( +
;00+ ,
set00- 0
;000 1
}002 3
public22 
int22 
?22 
RecurrenceInterval22 &
{22' (
get22) ,
;22, -
set22. 1
;221 2
}223 4
public44 
DateTime44 
?44 
NextDueDate44 $
{44% &
get44' *
;44* +
set44, /
;44/ 0
}441 2
[66 	
Required66	 
]66 
public77 
int77 
User_ID77 
{77 
get77  
;77  !
set77" %
;77% &
}77' (
}88 
}99 ±
ëC:\Users\rowan\Desktop\Tools\School\Semester 3\Ip\GamifyWork\Application\Backend\GamifyWork\src\GamifyWork.ServiceLibrary\Services\TaskService.cs
	namespace		 	

GamifyWork		
 
.		 
ServiceLibrary		 #
.		# $
Services		$ ,
{

 
public 

class 
TaskService 
: 
ITaskService +
{ 
private 
readonly 
ITaskRepository (
_taskRepository) 8
;8 9
public 
TaskService 
( 
ITaskRepository *
taskRepository+ 9
)9 :
{ 	
_taskRepository 
= 
taskRepository ,
;, -
} 	
public 
async 
Task 
< 
IEnumerable %
>% &
GetAllTasks' 2
(2 3
)3 4
{ 	
try 
{ 
var 
tasks 
= 
await !
_taskRepository" 1
.1 2
GetAllTasks2 =
(= >
)> ?
;? @
return 
( 
tasks 
) 
; 
} 
catch 
( 
	Exception 
ex 
)  
{ 
throw 
new 
	Exception #
(# $
ex$ &
.& '
Message' .
). /
;/ 0
} 
} 	
} 
}   