«
eC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Extension\ControllerExtension.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
	Extension$ -
{ 
public 

static 
class 
ControllerExtension +
{ 
public 
static 
void 
ConfigureController .
(. /
this/ 3
IServiceCollection4 F
servicesG O
)O P
{ 	
services 
. 
AddControllers #
(# $
)$ %
.% &'
ConfigureApiBehaviorOptions& A
(A B
optB E
=>F H
{ 
opt 
. ,
 InvalidModelStateResponseFactory 4
=5 6
context7 >
=>? A
{ 
var 
	errorList !
=" #
context$ +
.+ ,

ModelState, 6
.6 7
ToDictionary7 C
(C D
kvp 
=> 
kvp "
." #
Key# &
,& '
kvp 
=> 
kvp "
." #
Value# (
.( )
Errors) /
./ 0
Select0 6
(6 7
e7 8
=>9 ;
e< =
.= >
ErrorMessage> J
)J K
.K L
ToArrayL S
(S T
)T U
) 
; 
var 
response  
=! "
new# &
GenericResponse' 6
<6 7

Dictionary7 A
<A B
stringB H
,H I
stringJ P
[P Q
]Q R
>R S
>S T
{ 
Code 
= 
(  
int  #
)# $
Models$ *
.* +
Enums+ 0
.0 1
MessageCodesApi1 @
.@ A
ModelInvalidA M
,M N
ResponseType $
=% &
Models' -
.- .
Enums. 3
.3 4
ResponseType4 @
.@ A
ErrorA F
.F G
GetEnumMemberG T
(T U
)U V
,V W
Content 
=  !
	errorList" +
,+ ,
Message   
=    !
Models  " (
.  ( )
Enums  ) .
.  . /
MessageCodesApi  / >
.  > ?
ModelInvalid  ? K
.  K L
GetEnumMember  L Y
(  Y Z
)  Z [
}!! 
;!! 
var"" 
result"" 
=""  
new""! $"
BadRequestObjectResult""% ;
(""; <
response""< D
)""D E
;""E F
result## 
.## 
ContentTypes## '
.##' (
Add##( +
(##+ ,
MediaTypeNames##, :
.##: ;
Application##; F
.##F G
Json##G K
)##K L
;##L M
return$$ 
result$$ !
;$$! "
}%% 
;%% 
}&& 
)'' 
.'' 
AddJsonOptions'' 
('' 
options'' $
=>''% '
options(( 
.(( !
JsonSerializerOptions(( %
.((% &

Converters((& 0
.((0 1
Add((1 4
(((4 5
new((5 8#
JsonStringEnumConverter((9 P
(((P Q
)((Q R
)((R S
)((S T
;((T U
})) 	
}** 
}++ ˇ
_C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Extension\EnumExtension.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
	Extension$ -
{		 
public

 

static

 
class

 
EnumExtension

 %
{ 
public 
static 
string 
GetEnumDescription /
(/ 0
Enum0 4
value5 :
): ;
{ 	
var 
fi 
= 
value 
. 
GetType "
(" #
)# $
.$ %
GetField% -
(- .
value. 3
.3 4
ToString4 <
(< =
)= >
)> ?
;? @
if 
( 
fi 
. 
GetCustomAttributes &
(& '
typeof' -
(- . 
DescriptionAttribute. B
)B C
,C D
falseE J
)J K
isL N 
DescriptionAttributeO c
[c d
]d e

attributesf p
&&q s

attributest ~
.~ 
Any	 Ç
(
Ç É
)
É Ñ
)
Ñ Ö
{ 
return 

attributes !
.! "
First" '
(' (
)( )
.) *
Description* 5
;5 6
} 
return 
value 
. 
ToString !
(! "
)" #
;# $
} 	
public 
static 
string 
GetEnumMember *
(* +
this+ /
Enum0 4
@enum5 :
): ;
{ 	
var 
attr 
= 
@enum 
. 
GetType $
($ %
)% &
.& '
	GetMember' 0
(0 1
@enum1 6
.6 7
ToString7 ?
(? @
)@ A
)A B
.B C
FirstOrDefaultC Q
(Q R
)R S
?S T
.& '
GetCustomAttributes' :
(: ;
false; @
)@ A
.A B
OfTypeB H
<H I
EnumMemberAttributeI \
>\ ]
(] ^
)^ _
.& '
FirstOrDefault' 5
(5 6
)6 7
;7 8
return 
attr 
== 
null 
?  !
@enum" '
.' (
ToString( 0
(0 1
)1 2
:3 4
attr5 9
.9 :
Value: ?
;? @
} 	
} 
}   ˆ.
bC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Extension\SwaggerExtension.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
	Extension$ -
{ 
public 

static 
class 
SwaggerExtension (
{		 
public

 
static

 
void

 $
ConfigureSwaggerServices

 3
(

3 4
this

4 8
IServiceCollection

9 K
services

L T
)

T U
{ 	
services 
. 
AddSwaggerGen "
(" #
c# $
=>% '
{ 
var  
bearerSecurityScheme (
=) *
new+ .!
OpenApiSecurityScheme/ D
{ 
Description 
=  !
$str	" ®
,
® ©
Name 
= 
$str *
,* +
In 
= 
ParameterLocation *
.* +
Header+ 1
,1 2
Type 
= 
SecuritySchemeType -
.- .
ApiKey. 4
,4 5
Scheme 
= 
$str %
,% &
BearerFormat  
=! "
$str# (
,( )
	Reference 
= 
new  #
OpenApiReference$ 4
{ 
Id 
= 
$str (
,( )
Type 
= 
ReferenceType ,
., -
SecurityScheme- ;
} 
} 
; 
c 
. !
AddSecurityDefinition '
(' ( 
bearerSecurityScheme( <
.< =
	Reference= F
.F G
IdG I
,I J 
bearerSecuritySchemeK _
)_ `
;` a
c 
. "
AddSecurityRequirement (
(( )
new) ,&
OpenApiSecurityRequirement- G
(G H
)H I
{   
{!!  
bearerSecurityScheme"" ,
,"", -
new## 
List##  
<##  !
string##! '
>##' (
(##( )
)##) *
}$$ 
}%% 
)%% 
;%% 
c&& 
.&& 
DocumentFilter&&  
<&&  !
SwaggerIgnoreFilter&&! 4
>&&4 5
(&&5 6
)&&6 7
;&&7 8
}'' 
)'' 
;'' 
}** 	
public++ 
class++ 
SwaggerIgnoreFilter++ (
:++) *
IDocumentFilter+++ :
{,, 	
public-- 
void-- 
Apply-- 
(-- 
OpenApiDocument-- -

swaggerDoc--. 8
,--8 9!
DocumentFilterContext--: O
context--P W
)--W X
{.. 
foreach// 
(// 
var// 
path// !
in//" $

swaggerDoc//% /
./// 0
Paths//0 5
)//5 6
{00 
foreach11 
(11 
var11  
	operation11! *
in11+ -
path11. 2
.112 3
Value113 8
.118 9

Operations119 C
)11C D
{22 
var33 

parameters33 &
=33' (
	operation33) 2
.332 3
Value333 8
.338 9

Parameters339 C
.33C D
ToList33D J
(33J K
)33K L
;33L M
foreach44 
(44  !
var44! $
	parameter44% .
in44/ 1

parameters442 <
)44< =
{55 
DeleteParams66 (
(66( )
	parameter66) 2
,662 3
	operation664 =
)66= >
;66> ?
}77 
}88 
}99 
}:: 
private;; 
static;; 
void;; 
DeleteParams;;  ,
(;;, -
OpenApiParameter;;- =
	parameter;;> G
,;;G H
KeyValuePair;;I U
<;;U V
OperationType;;V c
,;;c d
OpenApiOperation;;e u
>;;u v
	operation	;;w Ä
)
;;Ä Å
{<< 
if== 
(== 
	parameter== 
.== 
Name== "
.==" #

StartsWith==# -
(==- .
$str==. :
)==: ;
)==; <
	operation>> 
.>> 
Value>> #
.>># $

Parameters>>$ .
.>>. /
Remove>>/ 5
(>>5 6
	parameter>>6 ?
)>>? @
;>>@ A
if?? 
(?? 
	parameter?? 
.?? 
Name?? "
.??" #
ToUpper??# *
(??* +
)??+ ,
.??, -

StartsWith??- 7
(??7 8
$str??8 <
)??< =
&&??> @
(@@ 
	operation@@ 
.@@ 
Key@@ 
==@@ !
OperationType@@" /
.@@/ 0
Get@@0 3
||AA 
	operationAA 
.AA 
KeyAA  
==AA! #
OperationTypeAA$ 1
.AA1 2
DeleteAA2 8
)AA8 9
&&AA: <
	parameterBB 
.BB 
InBB 
==BB  
ParameterLocationBB! 2
.BB2 3
QueryBB3 8
)BB8 9
	operationCC 
.CC 
ValueCC #
.CC# $

ParametersCC$ .
.CC. /
RemoveCC/ 5
(CC5 6
	parameterCC6 ?
)CC? @
;CC@ A
ifDD 
(DD 
	parameterDD 
.DD 
NameDD "
.DD" #

StartsWithDD# -
(DD- .
$strDD. ;
)DD; <
)DD< =
	operationEE 
.EE 
ValueEE #
.EE# $

ParametersEE$ .
.EE. /
RemoveEE/ 5
(EE5 6
	parameterEE6 ?
)EE? @
;EE@ A
}FF 
}GG 	
}HH 
}II ı
dC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Filters\ModelFilterAttribute.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
Filters$ +
{		 
public

 

class

  
ModelFilterAttribute

 %
:

& '!
ActionFilterAttribute

( =
{ 
private 
readonly 
ITokenService &
tokenService' 3
;3 4
private 
readonly 
ValidateIntegrity *
validateIntegrity+ <
;< =
public  
ModelFilterAttribute #
(# $
ITokenService$ 1
tokenService2 >
,> ?
ValidateIntegrity -
validateIntegrity. ?
)? @
{ 	
this 
. 
tokenService 
= 
tokenService  ,
;, -
this 
. 
validateIntegrity "
=# $
validateIntegrity% 6
;6 7
} 	
public 
override 
async 
Task ""
OnActionExecutionAsync# 9
(9 :"
ActionExecutingContext: P
contextQ X
,X Y#
ActionExecutionDelegateZ q
nextr v
)v w
{ 	
var 
test 
= 
context "
." #
ActionDescriptor# 3
.3 4

Parameters4 >
;> ?
foreach 
( 
var 
parameterDescriptor ,
in- /
test0 4
)4 5
{ 
var 
parameterInterfaces '
=( )
parameterDescriptor* =
.= >
ParameterType> K
.K L
GetInterfacesL Y
(Y Z
)Z [
;[ \
if 
( 
! 
parameterInterfaces (
.( )
Any) ,
(, -
t- .
=>/ 1
t2 3
==4 6
typeof7 =
(= >
IRequestBase> J
)J K
)K L
)L M
continueN V
;V W
var   
modelContext    
=  ! "
(  # $
IRequestBase  $ 0
)  0 1
context  1 8
.  8 9
ActionArguments  9 H
[  H I
parameterDescriptor  I \
.  \ ]
Name  ] a
]  a b
;  b c
modelContext!! 
.!! 

TokenModel!! '
=!!( )
tokenService!!* 6
.!!6 7
GetTokenModel!!7 D
(!!D E
context!!E L
.!!L M
HttpContext!!M X
)!!X Y
;!!Y Z
modelContext"" 
."" 
UserContext"" (
="") *
await"", 1
validateIntegrity""2 C
.""C D
ValidateUser""D P
(""P Q
modelContext""Q ]
)""] ^
;""^ _
}## 
await$$ 
base$$ 
.$$ "
OnActionExecutionAsync$$ -
($$- .
context$$. 5
,$$5 6
next$$7 ;
)$$; <
;$$< =
}%% 	
}&& 
}(( ≤
hC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Mapper\Candidate\CandidateMapper.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
Mapper$ *
.* +
	Candidate+ 4
{ 
public 

static 
class 
CandidateMapper '
{ 
public 
static 
void !
ConfigCandidateMapper 0
(0 1
this1 5
CustomMapperDto6 E
profileF M
)M N
{		 	
profile 
. 
	CreateMap 
< "
CandidateCreateRequest 4
,4 5
Models6 <
.< =

Persitence= G
.G H
	CandidateH Q
>Q R
(R S
)S T
;T U
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
	Candidate0 9
,9 :#
CandidateCreateResponse; R
>R S
(S T
)T U
;U V
profile 
. 
	CreateMap 
< "
CandidateUpdateRequest 4
,4 5
Models6 <
.< =

Persitence= G
.G H
	CandidateH Q
>Q R
(R S
)S T
;T U
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
	Candidate0 9
,9 :#
CandidateUpdateResponse; R
>R S
(S T
)T U
;U V
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
	Candidate0 9
,9 :#
CandidateDeleteResponse; R
>R S
(S T
)T U
;U V
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
	Candidate0 9
,9 :!
CandidateResponseBase; P
>P Q
(Q R
)R S
;S T
} 	
} 
} ¥
^C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Mapper\CustomMapperDTO.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
Mapper$ *
{		 
public

 

class

 
CustomMapperDto

  
:

! "
Profile

# *
{ 
public 
CustomMapperDto 
( 
)  
{ 	
this 
. 
ConfigEventMapper "
(" #
)# $
;$ %
this 
. 
ConfigUserMapper !
(! "
)" #
;# $
this 
. !
ConfigCandidateMapper &
(& '
)' (
;( )
this 
. 
ConfigVoteMapper !
(! "
)" #
;# $
this 
. *
ConfigEventAdministratorMapper /
(/ 0
)0 1
;1 2
} 	
} 
} †
zC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Mapper\EventAdministrator\EventAdministratorMapper.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
Mapper$ *
.* +
EventAdministrator+ =
{ 
public 

static 
class $
EventAdministratorMapper 0
{ 
public 
static 
void *
ConfigEventAdministratorMapper 9
(9 :
this: >
CustomMapperDto? N
profileO V
)V W
{		 	
profile 
. 
	CreateMap 
< +
EventAdministratorCreateRequest =
,= >
Models? E
.E F

PersitenceF P
.P Q
EventAdministratorQ c
>c d
(d e
)e f
;f g
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
EventAdministrator0 B
,B C,
 EventAdministratorCreateResponseD d
>d e
(e f
)f g
;g h
profile 
. 
	CreateMap 
< +
EventAdministratorDeleteRequest =
,= >
Models? E
.E F

PersitenceF P
.P Q
EventAdministratorQ c
>c d
(d e
)e f
;f g
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
EventAdministrator0 B
,B C,
 EventAdministratorDeleteResponseD d
>d e
(e f
)f g
;g h
profile 
. 
	CreateMap 
< +
EventAdministratorUpdateRequest =
,= >
Models? E
.E F

PersitenceF P
.P Q
EventAdministratorQ c
>c d
(d e
)e f
;f g
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
EventAdministrator0 B
,B C,
 EventAdministratorUpdateResponseD d
>d e
(e f
)f g
;g h
profile 
. 
	CreateMap 
< (
EventAdministratorGetRequest :
,: ;
Models< B
.B C

PersitenceC M
.M N
EventAdministratorN `
>` a
(a b
)b c
;c d
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
EventAdministrator0 B
,B C*
EventAdministratorResponseBaseD b
>b c
(c d
)d e
;e f
} 	
} 
} è
`C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Mapper\Event\EventMapper.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
Mapper$ *
.* +
Event+ 0
{ 
public 

static 
class 
EventMapper #
{ 
public 
static 
void 
ConfigEventMapper ,
(, -
this- 1
CustomMapperDto2 A
profileB I
)I J
{		 	
profile 
. 
	CreateMap 
< 
EventCreateRequest 0
,0 1
Models2 8
.8 9

Persitence9 C
.C D
EventD I
>I J
(J K
)K L
;L M
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
Event0 5
,5 6
EventCreateResponse7 J
>J K
(K L
)L M
;M N
profile 
. 
	CreateMap 
< 
EventDeleteRequest 0
,0 1
Models2 8
.8 9

Persitence9 C
.C D
EventD I
>I J
(J K
)K L
;L M
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
Event0 5
,5 6
EventDeleteResponse7 J
>J K
(K L
)L M
;M N
profile 
. 
	CreateMap 
< 
EventUpdateRequest 0
,0 1
Models2 8
.8 9

Persitence9 C
.C D
EventD I
>I J
(J K
)K L
;L M
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
Event0 5
,5 6
EventUpdateResponse7 J
>J K
(K L
)L M
;M N
profile 
. 
	CreateMap 
< 
EventGetRequest -
,- .
Models/ 5
.5 6

Persitence6 @
.@ A
EventA F
>F G
(G H
)H I
;I J
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
Event0 5
,5 6
EventResponseBase7 H
>H I
(I J
)J K
;K L
} 	
} 
} ›
^C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Mapper\User\UserMapper.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
Mapper$ *
.* +
User+ /
{ 
public 

static 
class 

UserMapper "
{ 
public 
static 
void 
ConfigUserMapper +
(+ ,
this, 0
CustomMapperDto1 @
profileA H
)H I
{		 	
profile 
. 
	CreateMap 
< 
UserCreateRequest 0
,0 1
Models2 8
.8 9

Persitence9 C
.C D
UserD H
>H I
(I J
)J K
;K L
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
User0 4
,4 5
UserCreateResponse6 H
>H I
(I J
)J K
;K L
profile 
. 
	CreateMap 
< 
UserUpdateRequest /
,/ 0
Models1 7
.7 8

Persitence8 B
.B C
UserC G
>G H
(H I
)I J
;J K
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
User0 4
,4 5
UserUpdateResponse6 H
>H I
(I J
)J K
;K L
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
User0 4
,4 5
UserDeleteResponse6 H
>H I
(I J
)J K
;K L
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
User0 4
,4 5
UserResponseBase6 F
>F G
(G H
)H I
;I J
} 	
} 
} ˙
^C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Mapper\Vote\VoteMapper.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
Mapper$ *
.* +
Vote+ /
{ 
public 

static 
class 

VoteMapper "
{ 
public		 
static		 
void		 
ConfigVoteMapper		 +
(		+ ,
this		, 0
CustomMapperDto		1 @
profile		A H
)		H I
{

 	
profile 
. 
	CreateMap 
<  
VoteCreateRequest  1
,1 2
Models3 9
.9 :

Persitence: D
.D E
VoteE I
>I J
(J K
)K L
;L M
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
Vote0 4
,4 5
VoteCreateResponse6 H
>H I
(I J
)J K
;K L
profile 
. 
	CreateMap 
< 
VoteDeleteRequest /
,/ 0
Models1 7
.7 8

Persitence8 B
.B C
VoteC G
>G H
(H I
)I J
;J K
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
Vote0 4
,4 5
VoteDeleteResponse6 H
>H I
(I J
)J K
;K L
profile 
. 
	CreateMap 
< 
VoteUpdateRequest /
,/ 0
Models1 7
.7 8

Persitence8 B
.B C
VoteC G
>G H
(H I
)I J
;J K
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
Vote0 4
,4 5
VoteUpdateResponse6 H
>H I
(I J
)J K
;K L
profile 
. 
	CreateMap 
< 
VoteGetRequest ,
,, -
Models. 4
.4 5

Persitence5 ?
.? @
Vote@ D
>D E
(E F
)F G
;G H
profile 
. 
	CreateMap 
< 
Models $
.$ %

Persitence% /
./ 0
Vote0 4
,4 5
VoteResponseBase6 F
>F G
(G H
)H I
;I J
} 	
} 
} ´
bC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Mediator\MediatorCandidate.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
Mediator$ ,
{ 
public		 

static		 
class		 
MediatorCandidate		 )
{

 
public 
static 
void %
AddIMediaRCandidateConfig 4
(4 5
this5 9
IServiceCollection: L
servicesM U
)U V
{ 	
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2"
CandidateCreateRequest2 H
,H I#
CandidateCreateResponseJ a
>a b
,b c"
CandidateCreateHandlerd z
>z {
({ |
)| }
;} ~
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2"
CandidateUpdateRequest2 H
,H I#
CandidateUpdateResponseJ a
>a b
,b c"
CandidateUpdateHandlerd z
>z {
({ |
)| }
;} ~
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2"
CandidateDeleteRequest2 H
,H I#
CandidateDeleteResponseJ a
>a b
,b c"
CandidateDeleteHandlerd z
>z {
({ |
)| }
;} ~
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2
CandidateGetRequest2 E
,E F 
CandidateGetResponseG [
>[ \
,\ ]
CandidateGetHandler^ q
>q r
(r s
)s t
;t u
} 	
} 
} Ô
^C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Mediator\MediatorEvent.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
Mediator$ ,
{ 
public		 

static		 
class		 
MediatorEvent		 %
{

 
public 
static 
void !
AddIMediaREventConfig 3
(3 4
this4 8
IServiceCollection9 K
servicesL T
)T U
{ 	
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2
EventCreateRequest2 D
,D E
EventCreateResponseF Y
>Y Z
,Z [
EventCreateHandler\ n
>n o
(o p
)p q
;q r
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2
EventDeleteRequest2 D
,D E
EventDeleteResponseF Y
>Y Z
,Z [
EventDeleteHandler\ n
>n o
(o p
)p q
;q r
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2
EventUpdateRequest2 D
,D E
EventUpdateResponseF Y
>Y Z
,Z [
EventUpdateHandler\ n
>n o
(o p
)p q
;q r
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2
EventGetRequest2 A
,A B
EventGetResponseC S
>S T
,T U
EventGetHandlerV e
>e f
(f g
)g h
;h i
} 	
} 
} ‰
cC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Mediator\MediatorExtensi√≥n.cs
	namespace

 	
Dach


 
.

 
ElectionSystem

 
.

 
Utils

 #
.

# $
Mediator

$ ,
{ 
public 

static 
class 
MediatorExtensi√≥n )
{ 
public 
static 
void 
AddIMediaRServices -
(- .
this. 2
IServiceCollection3 E
servicesF N
)N O
{ 	
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2
LoginRequest2 >
,> ?
LoginResponse@ M
>M N
,N O
AuthHandlerP [
>[ \
(\ ]
)] ^
;^ _
MediatorUser 
.  
AddIMediaRUserConfig -
(- .
services. 6
)6 7
;7 8
MediatorEvent 
. !
AddIMediaREventConfig /
(/ 0
services0 8
)8 9
;9 :
MediatorCandidate 
. %
AddIMediaRCandidateConfig 7
(7 8
services8 @
)@ A
;A B
MediatorVote 
.  
AddIMediaRVoteConfig -
(- .
services. 6
)6 7
;7 8
} 	
} 
} ‡
]C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Mediator\MediatorUser.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
Mediator$ ,
{ 
public		 

static		 
class		 
MediatorUser		 $
{

 
public 
static 
void  
AddIMediaRUserConfig 2
(2 3
this3 7
IServiceCollection8 J
servicesK S
)S T
{ 	
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2
UserCreateRequest2 C
,C D
UserCreateResponseE W
>W X
,X Y
UserCreateHandlerZ k
>k l
(l m
)m n
;n o
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2
UserUpdateRequest2 C
,C D
UserUpdateResponseE W
>W X
,X Y
UserUpdateHandlerZ k
>k l
(l m
)m n
;n o
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2
UserDeleteRequest2 C
,C D
UserDeleteResponseE W
>W X
,X Y
UserDeleteHandlerZ k
>k l
(l m
)m n
;n o
services 
. 
AddTransient !
<! "
IRequestHandler" 1
<1 2
UserGetRequest2 @
,@ A
UserGetResponseB Q
>Q R
,R S
UserGetHandlerT b
>b c
(c d
)d e
;e f
} 	
} 
} »
]C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\Mediator\MediatorVote.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
Mediator$ ,
{ 
public 

static 
class 
MediatorVote $
{ 
public 
static 
void  
AddIMediaRVoteConfig /
(/ 0
this0 4
IServiceCollection5 G
servicesH P
)P Q
{ 	
if 
( 
services 
is 
null  
)  !
{ 
throw 
new 
System  
.  !!
ArgumentNullException! 6
(6 7
nameof7 =
(= >
services> F
)F G
)G H
;H I
} 
} 	
} 
} À-
uC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\MiddlewareHandler\ExceptionHandlingMiddleware.cs
	namespace

 	
Dach


 
.

 
ElectionSystem

 
.

 
Utils

 #
.

# $
MiddlewareHandler

$ 5
{ 
public 

class '
ExceptionHandlingMiddleware ,
{ 
private 
readonly 
RequestDelegate (
_next) .
;. /
private 
readonly 
ILogger  
<  !'
ExceptionHandlingMiddleware! <
>< =
logger> D
;D E
public '
ExceptionHandlingMiddleware *
(* +
RequestDelegate+ :
next; ?
,? @
ILoggerA H
<H I'
ExceptionHandlingMiddlewareI d
>d e
loggerf l
)l m
{ 	
_next 
= 
next 
; 
this 
. 
logger 
= 
logger  
;  !
} 	
public&& 
async&& 
Task&& 
InvokeAsync&& %
(&&% &
HttpContext&&& 1
httpContext&&2 =
)&&= >
{'' 	
try(( 
{)) 
await** 
_next** 
(** 
httpContext** '
)**' (
.**( )
ConfigureAwait**) 7
(**7 8
false**8 =
)**= >
;**> ?
}++ 
catch,, 
(,, 
CustomException,, "
customEx,,# +
),,+ ,
{-- 
await.. &
HandleCustomExceptionAsync.. 0
(..0 1
httpContext..1 <
,..< =
customEx..> F
)..F G
;..G H
}// 
catch00 
(00 
	Exception00 
	exception00 &
)00& '
{11 
logger22 
.22 
LogError22 
(22  
	exception22  )
,22) *
$str22* =
)22= >
;22> ?
await33  
HandleExceptionAsync33 *
(33* +
httpContext33+ 6
,336 7
	exception338 A
)33A B
;33B C
}44 
}55 	
private== 
static== 
Task== &
HandleCustomExceptionAsync== 6
(==6 7
HttpContext==7 B
context==C J
,==J K
CustomException==L [
customEx==\ d
)==d e
{>> 	
context@@ 
.@@ 
Response@@ 
.@@ 
ContentType@@ (
=@@) *
$str@@+ =
;@@= >
contextAA 
.AA 
ResponseAA 
.AA 

StatusCodeAA '
=AA( )
(AA* +
intAA+ .
)AA. /
customExAA/ 7
.AA7 8
CodeHttpAA8 @
;AA@ A
varBB 
responseBB 
=BB 
newBB 
GenericResponseBB .
<BB. /
stringBB/ 5
>BB5 6
{CC 
CodeDD 
=DD 
(DD 
intDD 
)DD 
customExDD $
.DD$ %
MessageCodesApiDD% 4
,DD4 5
ResponseTypeEE 
=EE 
customExEE '
.EE' (
ResponseTypeEE( 4
.EE4 5
ToStringEE5 =
(EE= >
)EE> ?
,EE? @
MessageFF 
=FF 
$"FF 
{FF 
customExFF %
.FF% &
MessageCodesApiFF& 5
.FF5 6
GetEnumMemberFF6 C
(FFC D
)FFD E
}FFE F
{FFG H
customExFFH P
.FFP Q
MessageSpecificFFQ `
}FF` a
"FFa b
}GG 
;GG 
returnHH 
contextHH 
.HH 
ResponseHH #
.HH# $

WriteAsyncHH$ .
(HH. /
responseHH/ 7
.HH7 8
ToStringHH8 @
(HH@ A
)HHA B
)HHB C
;HHC D
}II 	
privateJJ 
staticJJ 
TaskJJ  
HandleExceptionAsyncJJ 0
(JJ0 1
HttpContextJJ1 <
contextJJ= D
,JJD E
	ExceptionJJF O
	exceptionJJP Y
)JJY Z
{KK 	
contextMM 
.MM 
ResponseMM 
.MM 
ContentTypeMM (
=MM) *
$strMM+ =
;MM= >
contextNN 
.NN 
ResponseNN 
.NN 

StatusCodeNN '
=NN( )
StatusCodesNN* 5
.NN5 6(
Status500InternalServerErrorNN6 R
;NNR S
varOO 
responseOO 
=OO 
newOO 
GenericResponseOO .
<OO. /
stringOO/ 5
>OO5 6
{PP 
CodeQQ 
=QQ 
(QQ 
intQQ 
)QQ 
MessageCodesApiQQ +
.QQ+ ,
ErrorGenericQQ, 8
,QQ8 9
ResponseTypeRR 
=RR 
ResponseTypeRR +
.RR+ ,
ErrorRR, 1
.RR1 2
ToStringRR2 :
(RR: ;
)RR; <
,RR< =
MessageSS 
=SS 
	exceptionSS #
.SS# $
MessageSS$ +
+SS, -
	exceptionSS. 7
.SS7 8
InnerExceptionSS8 F
??SSF H
StringSSI O
.SSO P
EmptySSP U
,SSU V
ContentTT 
=TT 
nullTT 
}UU 
;UU 
returnVV 
contextVV 
.VV 
ResponseVV #
.VV# $

WriteAsyncVV$ .
(VV. /
responseVV/ 7
.VV7 8
ToStringVV8 @
(VV@ A
)VVA B
)VVB C
;VVC D
}WW 	
}YY 
}ZZ ›
tC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\MiddlewareHandler\JwtAuthenticationMiddlware.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
Segurity$ ,
., -
JWT- 0
{ 
public 

class &
JwtAuthenticationMiddlware +
{		 
private 
readonly 
RequestDelegate (
_next) .
;. /
public &
JwtAuthenticationMiddlware )
() *
RequestDelegate* 9
next: >
)> ?
{ 	
_next 
= 
next 
; 
} 	
public 
async 
Task 
Invoke  
(  !
HttpContext! ,
context- 4
,4 5
ITokenService6 C
tokenServiceD P
)P Q
{ 	
if 
( 

IsUrlAllow 
( 
context "
)" #
)# $
{ 
await 
_next 
. 
Invoke "
(" #
context# *
)* +
;+ ,
} 
else 
{ 
tokenService 
. 
ValidateToken *
(* +
context+ 2
)2 3
;3 4
await 
_next 
. 
Invoke "
(" #
context# *
)* +
;+ ,
} 
} 	
private 
static 
bool 

IsUrlAllow &
(& '
HttpContext' 2
request3 :
): ;
{ 	
var   
baseUrl   
=   
$"   
/api    
"    !
;  ! "
return!! 
request"" 
."" 
Request"" 
.""  
Path""  $
.""$ %
StartsWithSegments""% 7
(""7 8
$str""8 B
)""B C
||""D F
request## 
.## 
Request## 
.##  
Path##  $
.##$ %
StartsWithSegments##% 7
(##7 8
baseUrl##8 ?
+##@ A
$str##B I
)##I J
||##J L
($$ 
request$$ 
.$$ 
Request$$  
.$$  !
Path$$! %
==$$% '
($$' (
baseUrl$$( /
+$$0 1
$str$$2 :
)$$: ;
&&$$; =
request$$> E
.$$E F
Request$$F M
.$$M N
Method$$N T
==$$T V
$str$$V \
)$$\ ]
;$$] ^
}%% 	
}'' 
}(( ú
kC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\MiddlewareHandler\MiddleWareHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Utils #
.# $
MiddlewareHandler$ 5
{ 
public 

static 
class 
MiddleWareHandler )
{ 
public 
static 
IApplicationBuilder )
SetCustomMiddleWare* =
(= >
this> B
IApplicationBuilderC V
appW Z
)Z [
{		 	
app

 
.

 
UseMiddleware

 
<

 '
ExceptionHandlingMiddleware

 9
>

9 :
(

: ;
)

; <
;

< =
app 
. 
UseMiddleware 
< &
JwtAuthenticationMiddlware 8
>8 9
(9 :
): ;
;; <
return 
app 
; 
} 	
} 
} Ç
ÑC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\obj\Debug\net5.0\.NETCoreApp,Version=v5.0.AssemblyAttributes.cs
[ 
assembly 	
:	 

global 
:: 
System 
. 
Runtime !
.! "

Versioning" ,
., -$
TargetFrameworkAttribute- E
(E F
$strF `
,` a 
FrameworkDisplayNameb v
=w x
$stry {
){ |
]| }Ω
C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Utils\obj\Debug\net5.0\Dach.ElectionSystem.Utils.AssemblyInfo.cs
[ 
assembly 	
:	 

System 
. 

Reflection 
. $
AssemblyCompanyAttribute 5
(5 6
$str6 Q
)Q R
]R S
[ 
assembly 	
:	 

System 
. 

Reflection 
. *
AssemblyConfigurationAttribute ;
(; <
$str< C
)C D
]D E
[ 
assembly 	
:	 

System 
. 

Reflection 
. (
AssemblyFileVersionAttribute 9
(9 :
$str: C
)C D
]D E
[ 
assembly 	
:	 

System 
. 

Reflection 
. 1
%AssemblyInformationalVersionAttribute B
(B C
$strC J
)J K
]K L
[ 
assembly 	
:	 

System 
. 

Reflection 
. $
AssemblyProductAttribute 5
(5 6
$str6 Q
)Q R
]R S
[ 
assembly 	
:	 

System 
. 

Reflection 
. "
AssemblyTitleAttribute 3
(3 4
$str4 O
)O P
]P Q
[ 
assembly 	
:	 

System 
. 

Reflection 
. $
AssemblyVersionAttribute 5
(5 6
$str6 ?
)? @
]@ A