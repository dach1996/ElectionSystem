‘#
`C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Auth\AuthHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
Auth, 0
{ 
public 

class 
AuthHandler 
: 
IRequestHandler .
<. /
LoginRequest/ ;
,; <
LoginResponse= J
>J K
{ 
private 
readonly 
ITokenService &
_tokenService' 4
;4 5
private 
readonly 
string 

_secretKey  *
;* +
private 
readonly 
IUserRepository (
_usuarioRepository) ;
;; <
public 
AuthHandler 
( 
IUserRepository 
usuarioRepository -
,- .
ITokenService 
tokenService &
,& '
IConfiguration 
configuration (
)( )
{ 	
_usuarioRepository 
=  
usuarioRepository! 2
;2 3
_tokenService 
= 
tokenService (
;( )

_secretKey 
= 
configuration &
.& '

GetSection' 1
(1 2
$str2 =
)= >
.> ?
Value? D
;D E
} 	
public"" 
async"" 
Task"" 
<"" 
LoginResponse"" '
>""' (
Handle"") /
(""/ 0
LoginRequest""0 <
request""= D
,""D E
CancellationToken""F W
cancellationToken""X i
)""i j
{## 	
var$$ 
passwordHash$$ 
=$$ 
Common$$ %
.$$% &
Util$$& *
.$$* +
ComputeSHA256$$+ 8
($$8 9
request$$9 @
.$$@ A
Password$$A I
,$$I J

_secretKey$$K U
)$$U V
;$$V W
var%% 
user%% 
=%% 
(%% 
await%% 
_usuarioRepository%% 0
.%%0 1
GetAsync%%1 9
(%%9 :
u%%: ;
=>%%< >
u%%? @
.%%@ A
Email%%A F
==%%G I
request%%J Q
.%%Q R
Email%%R W
&&%%X Z
(%%[ \
u%%\ ]
.%%] ^
Password%%^ f
==%%g i
passwordHash%%j v
||%%w y
u%%z {
.%%{ |
TemPassword	%%| á
==
%%à ä
passwordHash
%%ã ó
)
%%ó ò
)
%%ò ô
)
%%ô ö
.
%%ö õ
FirstOrDefault
%%õ ©
(
%%© ™
)
%%™ ´
;
%%´ ¨
if&& 
(&& 
user&& 
==&& 
null&& 
)&& 
throw'' 
new'' 
CustomException'' )
('') *
Models''* 0
.''0 1
Enums''1 6
.''6 7
MessageCodesApi''7 F
.''F G
IncorrectData''G T
,''T U
Models''V \
.''\ ]
Enums''] b
.''b c
ResponseType''c o
.''o p
Error''p u
,''u v
System''w }
.''} ~
Net	''~ Å
.
''Å Ç
HttpStatusCode
''Ç ê
.
''ê ë
Unauthorized
''ë ù
)
''ù û
;
''û ü
if(( 
((( 
!(( 
user(( 
.(( 
IsActive(( 
)(( 
throw)) 
new)) 
CustomException)) )
())) *
Models))* 0
.))0 1
Enums))1 6
.))6 7
MessageCodesApi))7 F
.))F G
UserIsInactive))G U
,))U V
Models))W ]
.))] ^
Enums))^ c
.))c d
ResponseType))d p
.))p q
Error))q v
,))v w
System))x ~
.))~ 
Net	)) Ç
.
))Ç É
HttpStatusCode
))É ë
.
))ë í
Unauthorized
))í û
)
))û ü
;
))ü †
var** 
token** 
=** 
_tokenService** %
.**% &
GenerateTokenJwt**& 6
(**6 7
user**7 ;
)**; <
;**< =
return++ 
new++ 
LoginResponse++ $
(++$ %
)++% &
{++' (
Token++) .
=++/ 0
token++1 6
}++7 8
;++8 9
},, 	
}-- 
}.. Ö2
mC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Auth\ForggotenPasswordHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
Auth, 0
{ 
public 

class $
ForggotenPasswordHandler )
:* +
IRequestHandler, ;
<; <$
ForggotenPasswordRequest< T
,T U
UnitV Z
>Z [
{ 
private 
readonly 
Services !
.! "
Notification" .
.. /
INotification/ <
notification= I
;I J
private 
readonly 
string 

_secretKey  *
;* +
private 
readonly 
IUserRepository (
_usuarioRepository) ;
;; <
public $
ForggotenPasswordHandler '
(' (
IUserRepository 
usuarioRepository -
,- .
IConfiguration 
configuration (
,( )
Services 
. 
Notification  
.  !
INotification! .
notification/ ;
); <
{ 	
_usuarioRepository 
=  
usuarioRepository! 2
;2 3
this 
. 
notification 
= 
notification  ,
;, -

_secretKey 
= 
configuration &
.& '

GetSection' 1
(1 2
$str2 =
)= >
.> ?
Value? D
;D E
} 	
public!! 
async!! 
Task!! 
<!! 
Unit!! 
>!! 
Handle!!  &
(!!& '$
ForggotenPasswordRequest!!' ?
request!!@ G
,!!G H
CancellationToken!!I Z
cancellationToken!![ l
)!!l m
{"" 	
var## 
newPasswordGenerate## #
=##$ %
Common##& ,
.##, -
Util##- 1
.##1 2
GenerateCode##2 >
(##> ?
$num##? A
)##A B
;##B C
var$$ 
passwordHash$$ 
=$$ 
Common$$ %
.$$% &
Util$$& *
.$$* +
ComputeSHA256$$+ 8
($$8 9
newPasswordGenerate$$9 L
,$$L M

_secretKey$$N X
)$$X Y
;$$Y Z
var%% 
user%% 
=%% 
(%% 
await%% 
_usuarioRepository%% 0
.%%0 1
GetAsync%%1 9
(%%9 :
u%%: ;
=>%%< >
u%%? @
.%%@ A
Email%%A F
==%%G I
request%%J Q
.%%Q R
Email%%R W
)%%W X
)%%X Y
.%%Y Z
FirstOrDefault%%Z h
(%%h i
)%%i j
;%%j k
if&& 
(&& 
user&& 
==&& 
null&& 
)&& 
throw'' 
new'' 
CustomException'' )
('') *
Models''* 0
.''0 1
Enums''1 6
.''6 7
MessageCodesApi''7 F
.''F G
IncorrectData''G T
,''T U
Models''V \
.''\ ]
Enums''] b
.''b c
ResponseType''c o
.''o p
Error''p u
,''u v
System''w }
.''} ~
Net	''~ Å
.
''Å Ç
HttpStatusCode
''Ç ê
.
''ê ë
Unauthorized
''ë ù
)
''ù û
;
''û ü
user(( 
.(( 
TemPassword(( 
=(( 
passwordHash(( +
;((+ ,
var)) 
isUpdate)) 
=)) 
await))  
_usuarioRepository))! 3
.))3 4
Update))4 :
()): ;
user)); ?
)))? @
;))@ A
if** 
(** 
!** 
isUpdate** 
)** 
throw++ 
new++ 
CustomException++ )
(++) *
Models++* 0
.++0 1
Enums++1 6
.++6 7
MessageCodesApi++7 F
.++F G
NotUpdateRecord++G V
,++V W
Models++X ^
.++^ _
Enums++_ d
.++d e
ResponseType++e q
.++q r
Error++r w
,++w x
System++y 
.	++ Ä
Net
++Ä É
.
++É Ñ
HttpStatusCode
++Ñ í
.
++í ì!
InternalServerError
++ì ¶
)
++¶ ß
;
++ß ®
var,, 
isSend,, 
=,, 
notification,, %
.,,% &
SendMail,,& .
(,,. /
new-- 
Models-- 
.-- 
Mail-- 
.--  
	MailModel--  )
(--) *
)--* +
{.. 
From// 
=// 
$str// 7
,//7 8
Subject00 
=00 
$str00 4
,004 5
To11 
=11 
request11  
.11  !
Email11! &
,11& '
Template22 
=22 
$str22 C
,22C D
Params33 
=33 
new33  
{33! "
Username33# +
=33, -
$"33. 0
{330 1
user331 5
.335 6
	FirstName336 ?
}33? @
{33A B
user33B F
.33F G
FirstLastName33G T
}33T U
"33U V
,33V W
Password33X `
=33a b
newPasswordGenerate33c v
}33w x
}44 
)55 
;55 
if66 
(66 
!66 
isSend66 
)66 
throw77 
new77 
CustomException77 )
(77) *
Models77* 0
.770 1
Enums771 6
.776 7
MessageCodesApi777 F
.77F G
	MailError77G P
,77P Q
Models77R X
.77X Y
Enums77Y ^
.77^ _
ResponseType77_ k
.77k l
Error77l q
,77q r
System77s y
.77y z
Net77z }
.77} ~
HttpStatusCode	77~ å
.
77å ç!
InternalServerError
77ç †
)
77† °
;
77° ¢
return99 
Unit99 
.99 
Value99 
;99 
}:: 	
};; 
}<< ı-
pC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Candidate\CandidateCreateHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
	Candidate, 5
{ 
public 

class "
CandidateCreateHandler '
:( )
IRequestHandler* 9
<9 :"
CandidateCreateRequest: P
,P Q#
CandidateCreateResponseR i
>i j
{ 
private 
readonly  
ICandidateRepository -
candidateRepository. A
;A B
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
IEventRepository )
eventRepository* 9
;9 :
private 
readonly 
IUserRepository (
userRepository) 7
;7 8
public "
CandidateCreateHandler %
(% & 
ICandidateRepository  
candidateRepository! 4
,4 5
IMapper 
mapper 
, 
IEventRepository 
eventRepository ,
,, -
IUserRepository 
userRepository *
)* +
{ 	
this 
. 
candidateRepository $
=% &
candidateRepository' :
;: ;
this 
. 
mapper 
= 
mapper  
;  !
this 
. 
eventRepository  
=! "
eventRepository# 2
;2 3
this 
. 
userRepository 
=  !
userRepository" 0
;0 1
}   	
public$$ 
async$$ 
Task$$ 
<$$ #
CandidateCreateResponse$$ 1
>$$1 2
Handle$$3 9
($$9 :"
CandidateCreateRequest$$: P
request$$Q X
,$$X Y
CancellationToken$$Z k
cancellationToken$$l }
)$$} ~
{%% 	
var'' 
compareEvent'' 
='' 
(''  
await''  %
eventRepository''& 5
.''5 6
GetAsync''6 >
(''> ?
e''? @
=>''A C
e''D E
.''E F
Id''F H
==''I K
request''L S
.''S T
IdEvent''T [
)''[ \
)''\ ]
.''] ^
FirstOrDefault''^ l
(''l m
)''m n
;''n o
if(( 
((( 
compareEvent(( 
==(( 
null((  $
)(($ %
throw)) 
new)) 
CustomException)) )
())) *
Models))* 0
.))0 1
Enums))1 6
.))6 7
MessageCodesApi))7 F
.))F G
NotFindRecord))G T
,))T U
Models))V \
.))\ ]
Enums))] b
.))b c
ResponseType))c o
.))o p
Error))p u
,))u v
System))w }
.))} ~
Net	))~ Å
.
))Å Ç
HttpStatusCode
))Ç ê
.
))ê ë
NotFound
))ë ô
)
))ô ö
;
))ö õ
var** 
user** 
=** 
(** 
await** 
userRepository** ,
.**, -
GetAsync**- 5
(**5 6
u**6 7
=>**8 :
u**; <
.**< =
Id**= ?
==**@ B
request**C J
.**J K
IdUser**K Q
)**Q R
)**R S
.**S T
FirstOrDefault**T b
(**b c
)**c d
;**d e
if++ 
(++ 
user++ 
==++ 
null++ 
)++ 
throw,, 
new,, 
CustomException,, )
(,,) *
Models,,* 0
.,,0 1
Enums,,1 6
.,,6 7
MessageCodesApi,,7 F
.,,F G
NotFindRecord,,G T
,,,T U
Models,,V \
.,,\ ]
Enums,,] b
.,,b c
ResponseType,,c o
.,,o p
Error,,p u
,,,u v
System,,w }
.,,} ~
Net	,,~ Å
.
,,Å Ç
HttpStatusCode
,,Ç ê
.
,,ê ë
NotFound
,,ë ô
)
,,ô ö
;
,,ö õ
var-- 
newCandidate-- 
=-- 
mapper-- %
.--% &
Map--& )
<--) *
Models--* 0
.--0 1

Persitence--1 ;
.--; <
	Candidate--< E
>--E F
(--F G
request--G N
)--N O
;--O P
var.. 
isCreate.. 
=.. 
await..  
candidateRepository..! 4
...4 5
CreateAsync..5 @
(..@ A
newCandidate..A M
)..M N
;..N O
if00 
(00 
!00 
isCreate00 
)00 
throw11 
new11 
CustomException11 )
(11) *
Models11* 0
.110 1
Enums111 6
.116 7
MessageCodesApi117 F
.11F G
NotCreateRecord11G V
,11V W
Models11X ^
.11^ _
Enums11_ d
.11d e
ResponseType11e q
.11q r
Error11r w
,11w x
System11y 
.	11 Ä
Net
11Ä É
.
11É Ñ
HttpStatusCode
11Ñ í
.
11í ì!
InternalServerError
11ì ¶
)
11¶ ß
;
11ß ®
var22 
response22 
=22 
mapper22 !
.22! "
Map22" %
<22% &#
CandidateCreateResponse22& =
>22= >
(22> ?
newCandidate22? K
)22K L
;22L M
return33 
response33 
;33 
}44 	
}77 
}88 ä*
pC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Candidate\CandidateDeleteHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
	Candidate, 5
{ 
public 

class "
CandidateDeleteHandler '
:( )
IRequestHandler* 9
<9 :"
CandidateDeleteRequest: P
,P Q#
CandidateDeleteResponseR i
>i j
{ 
private 
readonly  
ICandidateRepository -
candidateRepository. A
;A B
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
IEventRepository )
eventRepository* 9
;9 :
public "
CandidateDeleteHandler %
(% & 
ICandidateRepository  
candidateRepository! 4
,4 5
IMapper 
mapper 
, 
IEventRepository 
eventRepository ,
) 
{ 	
this 
. 
candidateRepository $
=% &
candidateRepository' :
;: ;
this 
. 
mapper 
= 
mapper  
;  !
this 
. 
eventRepository  
=! "
eventRepository# 2
;2 3
} 	
public   
async   
Task   
<   #
CandidateDeleteResponse   1
>  1 2
Handle  3 9
(  9 :"
CandidateDeleteRequest  : P
request  Q X
,  X Y
CancellationToken  Z k
cancellationToken  l }
)  } ~
{!! 	
var## 
compareEvent## 
=## 
(##  
await##  %
eventRepository##& 5
.##5 6
GetAsync##6 >
(##> ?
e##? @
=>##A C
e##D E
.##E F
Id##F H
==##I K
request##L S
.##S T
IdEvent##T [
)##[ \
)##\ ]
.##] ^
FirstOrDefault##^ l
(##l m
)##m n
;##n o
if$$ 
($$ 
compareEvent$$ 
==$$ 
null$$  $
)$$$ %
throw%% 
new%% 
CustomException%% )
(%%) *
Models%%* 0
.%%0 1
Enums%%1 6
.%%6 7
MessageCodesApi%%7 F
.%%F G
NotFindRecord%%G T
,%%T U
Models%%V \
.%%\ ]
Enums%%] b
.%%b c
ResponseType%%c o
.%%o p
Error%%p u
,%%u v
System%%w }
.%%} ~
Net	%%~ Å
.
%%Å Ç
HttpStatusCode
%%Ç ê
.
%%ê ë
NotFound
%%ë ô
)
%%ô ö
;
%%ö õ
var&& 
	candidate&& 
=&& 
(&& 
await&& "
candidateRepository&&# 6
.&&6 7
GetAsync&&7 ?
(&&? @
u&&@ A
=>&&B D
u&&E F
.&&F G
Id&&G I
==&&J L
request&&M T
.&&T U
IdCandidate&&U `
)&&` a
)&&a b
.&&b c
FirstOrDefault&&c q
(&&q r
)&&r s
;&&s t
if'' 
('' 
	candidate'' 
=='' 
null'' !
)''! "
throw(( 
new(( 
CustomException(( )
((() *
Models((* 0
.((0 1
Enums((1 6
.((6 7
MessageCodesApi((7 F
.((F G
NotFindRecord((G T
,((T U
Models((V \
.((\ ]
Enums((] b
.((b c
ResponseType((c o
.((o p
Error((p u
,((u v
System((w }
.((} ~
Net	((~ Å
.
((Å Ç
HttpStatusCode
((Ç ê
.
((ê ë
NotFound
((ë ô
)
((ô ö
;
((ö õ
	candidate)) 
.)) 
IsActive)) 
=))  
false))! &
;))& '
var** 
isUpdate** 
=** 
await**  
candidateRepository**! 4
.**4 5
Update**5 ;
(**; <
	candidate**< E
)**E F
;**F G
if++ 
(++ 
!++ 
isUpdate++ 
)++ 
throw,, 
new,, 
CustomException,, )
(,,) *
Models,,* 0
.,,0 1
Enums,,1 6
.,,6 7
MessageCodesApi,,7 F
.,,F G
NotUpdateRecord,,G V
,,,V W
Models,,X ^
.,,^ _
Enums,,_ d
.,,d e
ResponseType,,e q
.,,q r
Error,,r w
,,,w x
System,,y 
.	,, Ä
Net
,,Ä É
.
,,É Ñ
HttpStatusCode
,,Ñ í
.
,,í ì!
InternalServerError
,,ì ¶
)
,,¶ ß
;
,,ß ®
var-- 
response-- 
=-- 
mapper-- !
.--! "
Map--" %
<--% &#
CandidateDeleteResponse--& =
>--= >
(--> ?
	candidate--? H
)--H I
;--I J
return.. 
response.. 
;.. 
}// 	
}22 
}33 Ô
mC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Candidate\CandidateGetHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
	Candidate, 5
{ 
public 

class 
CandidateGetHandler $
:% &
IRequestHandler' 6
<6 7
CandidateGetRequest7 J
,J K 
CandidateGetResponseL `
>` a
{ 
private 
readonly  
ICandidateRepository -
candidateRepository. A
;A B
private 
readonly 
IMapper  
mapper! '
;' (
public 
CandidateGetHandler "
(" # 
ICandidateRepository  
candidateRepository! 4
,4 5
IMapper 
mapper 
) 
{ 	
this 
. 
candidateRepository $
=% &
candidateRepository' :
;: ;
this 
. 
mapper 
= 
mapper  
;  !
} 	
public 
async 
Task 
<  
CandidateGetResponse .
>. /
Handle0 6
(6 7
CandidateGetRequest7 J
requestK R
,R S
CancellationTokenT e
cancellationTokenf w
)w x
{ 	
List 
< 
Models 
. 

Persitence "
." #
	Candidate# ,
>, -
listCandidates. <
;< =
listCandidates   
=   
(   
await   #
candidateRepository  $ 7
.  7 8
GetAsync  8 @
(  @ A
)  A B
)  B C
.  C D
ToList  D J
(  J K
)  K L
;  L M
var!! 
response!! 
=!! 
mapper!! !
.!!! "
Map!!" %
<!!% &
List!!& *
<!!* +!
CandidateResponseBase!!+ @
>!!@ A
>!!A B
(!!B C
listCandidates!!C Q
)!!Q R
;!!R S
return"" 
new""  
CandidateGetResponse"" +
(""+ ,
)"", -
{## 
ListCandidate$$ 
=$$ 
response$$  (
}%% 
;%% 
}&& 	
})) 
}** Ô%
pC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Candidate\CandidateUpdateHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
	Candidate, 5
{ 
public 

class "
CandidateUpdateHandler '
:( )
IRequestHandler* 9
<9 :"
CandidateUpdateRequest: P
,P Q#
CandidateUpdateResponseR i
>i j
{ 
private 
readonly  
ICandidateRepository - 
_candidateRepository. B
;B C
private 
readonly 
IMapper  
mapper! '
;' (
public "
CandidateUpdateHandler %
(% & 
ICandidateRepository  
candidateRepository! 4
,4 5
IMapper 
mapper 
) 
{ 	
this 
.  
_candidateRepository %
=& '
candidateRepository( ;
;; <
this 
. 
mapper 
= 
mapper  
;  !
} 	
public 
async 
Task 
< #
CandidateUpdateResponse 6
>6 7
Handle8 >
(> ?"
CandidateUpdateRequest? U
requestV ]
,] ^
CancellationToken_ p
cancellationToken	q Ç
)
Ç É
{ 	
var 
updateCandidate 
=  !
(" #
await# ( 
_candidateRepository) =
.= >
GetAsync> F
(F G
cG H
=>I K
cL M
.M N
IdN P
==P R
requestR Y
.Y Z
IdCandidateZ e
)e f
)f g
.g h
FirstOrDefaulth v
(v w
)w x
;x y
if   
(   
updateCandidate   
==    
null    $
)  $ %
throw!! 
new!! 
CustomException!! &
(!!& '
Models!!' -
.!!- .
Enums!!. 3
.!!3 4
MessageCodesApi!!4 C
.!!C D
NotFindRecord!!D Q
,!!Q R
Models!!S Y
.!!Y Z
Enums!!Z _
.!!_ `
ResponseType!!` l
.!!l m
Error!!m r
,!!r s
System!!t z
.!!z {
Net!!{ ~
.!!~ 
HttpStatusCode	!! ç
.
!!ç é
NotFound
!!é ñ
)
!!ñ ó
;
!!ó ò
updateCandidate## 
.## 
Age## 
=##  !
request##" )
.##) *
Age##* -
.##- .
Value##. 3
;##3 4
updateCandidate$$ 
.$$ 
Details$$ #
=$$$ %
request$$& -
.$$- .
Details$$. 5
;$$5 6
updateCandidate%% 
.%% 
Image%% !
=%%" #
request%%% ,
.%%, -
Image%%- 2
;%%2 3
updateCandidate&& 
.&& 
PostionsWorks&& )
=&&* +
request&&, 3
.&&3 4
PostionsWorks&&4 A
;&&A B
updateCandidate'' 
.'' 
Role''  
=''! "
request''# *
.''* +
Role''+ /
;''/ 0
updateCandidate(( 
.(( 
ProposalDetails(( +
=((, -
request((. 5
.((5 6
ProposalDetails((6 E
;((E F
var)) 
isUpdate)) 
=)) 
await))   
_candidateRepository))! 5
.))5 6
Update))6 <
())< =
updateCandidate))= L
)))L M
;))M N
if** 
(** 
!** 
isUpdate** 
)** 
throw++ 
new++ 
CustomException++ )
(++) *
Models++* 0
.++0 1
Enums++1 6
.++6 7
MessageCodesApi++7 F
.++F G
NotUpdateRecord++G V
,++V W
Models++X ^
.++^ _
Enums++_ d
.++d e
ResponseType++e q
.++q r
Error++r w
,++w x
System++y 
.	++ Ä
Net
++Ä É
.
++É Ñ
HttpStatusCode
++Ñ í
.
++í ì!
InternalServerError
++ì ¶
)
++¶ ß
;
++ß ®
var,, 
response,, 
=,, 
mapper,, !
.,,! "
Map,," %
<,,% &#
CandidateUpdateResponse,,& =
>,,= >
(,,> ?
updateCandidate,,? N
),,N O
;,,O P
return-- 
response-- 
;-- 
}.. 	
}11 
}22 á2
ÇC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\EventAdministrator\EventAdministratorCreateHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
EventAdministrator, >
{ 
public 

class +
EventAdministratorCreateHandler 0
:1 2
IRequestHandler3 B
<B C+
EventAdministratorCreateRequestC b
,b c-
 EventAdministratorCreateResponse	d Ñ
>
Ñ Ö
{ 
private 
readonly )
IEventAdministratorRepository 6)
_eventAdministratorRepository7 T
;T U
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
ValidateIntegrity *
validateIntegrity+ <
;< =
public +
EventAdministratorCreateHandler .
(. /)
IEventAdministratorRepository %(
EventAdministratorRepository& B
,B C
IMapper 
mapper 
, 
ValidateIntegrity 
validateIntegrity +
) 	
{ 	
this 
. )
_eventAdministratorRepository .
=/ 0(
EventAdministratorRepository1 M
;M N
this 
. 
_mapper 
= 
mapper !
;! "
this 
. 
validateIntegrity "
=# $
validateIntegrity% 6
;6 7
} 	
public!! 
async!! 
Task!! 
<!! ,
 EventAdministratorCreateResponse!! :
>!!: ;
Handle!!< B
(!!B C+
EventAdministratorCreateRequest!!C b
request!!c j
,!!j k
CancellationToken!!l }
cancellationToken	!!~ è
)
!!è ê
{"" 	
var$$ 
events$$ 
=$$ 
await$$ 
validateIntegrity$$ 0
.$$0 1
ValidateEvent$$1 >
($$> ?
request$$? F
.$$F G
IdEvent$$G N
)$$N O
;$$O P
var&& 
user&& 
=&& 
await&& 
validateIntegrity&& .
.&&. /
ValidateUser&&/ ;
(&&; <
request&&< C
.&&C D
IdUser&&D J
)&&J K
;&&K L
var(( &
isUserCurrentAdministrator(( *
=((+ ,
request((- 4
.((4 5
UserContext((5 @
.((@ A"
ListEventAdministrator((A W
.((W X
Exists((X ^
(((^ _
e((_ `
=>((a c
e((d e
.((e f
Id((f h
==((i k
events((l r
.((r s
Id((s u
)((u v
;((v w
if)) 
()) 
!)) &
isUserCurrentAdministrator)) ,
))), -
throw** 
new** 
CustomException** )
(**) *
Models*** 0
.**0 1
Enums**1 6
.**6 7
MessageCodesApi**7 F
.**F G
IncorrectData**G T
,**T U
Models**V \
.**\ ]
Enums**] b
.**b c
ResponseType**c o
.**o p
Error**p u
,**u v
System**w }
.**} ~
Net	**~ Å
.
**Å Ç
HttpStatusCode
**Ç ê
.
**ê ë
Conflict
**ë ô
,
**ô ö
$str++ S
)++S T
;++T U
var-- 
isUserAdministrator-- #
=--$ %
user--& *
.--* +"
ListEventAdministrator--+ A
.--A B
Exists--B H
(--H I
e--I J
=>--K M
e--N O
.--O P
Id--P R
==--S U
events--V \
.--\ ]
Id--] _
)--_ `
;--` a
if.. 
(.. 
isUserAdministrator.. #
)..# $
throw// 
new// 
CustomException// )
(//) *
Models//* 0
.//0 1
Enums//1 6
.//6 7
MessageCodesApi//7 F
.//F G
IncorrectData//G T
,//T U
Models//V \
.//\ ]
Enums//] b
.//b c
ResponseType//c o
.//o p
Error//p u
,//u v
System//w }
.//} ~
Net	//~ Å
.
//Å Ç
HttpStatusCode
//Ç ê
.
//ê ë
Conflict
//ë ô
,
//ô ö
$str00 Y
)00Y Z
;00Z [
var22 
eventAdministrator22 "
=22# $
new22% (
Models22) /
.22/ 0

Persitence220 :
.22: ;
EventAdministrator22; M
(22M N
)22N O
{33 
IdUser44 
=44 
user44 
.44 
Id44  
,44  !
IdEvent55 
=55 
events55  
.55  !
Id55! #
,55# $

Privileges66 
=66 
$str66 "
,66" #
Date77 
=77 
DateTime77 
.77  
Now77  #
}88 
;88 
var99 
isCreate99 
=99 
await99  )
_eventAdministratorRepository99! >
.99> ?
CreateAsync99? J
(99J K
eventAdministrator99K ]
)99] ^
;99^ _
if:: 
(:: 
!:: 
isCreate:: 
):: 
throw;; 
new;; 
CustomException;; )
(;;) *
Models;;* 0
.;;0 1
Enums;;1 6
.;;6 7
MessageCodesApi;;7 F
.;;F G
NotCreateRecord;;G V
,;;V W
Models;;X ^
.;;^ _
Enums;;_ d
.;;d e
ResponseType;;e q
.;;q r
Error;;r w
,;;w x
System;;y 
.	;; Ä
Net
;;Ä É
.
;;É Ñ
HttpStatusCode
;;Ñ í
.
;;í ì!
InternalServerError
;;ì ¶
)
;;¶ ß
;
;;ß ®
return<< 
_mapper<< 
.<< 
Map<< 
<<< ,
 EventAdministratorCreateResponse<< ?
><<? @
(<<@ A
eventAdministrator<<A S
)<<S T
;<<T U
}== 	
}?? 
}@@  :
ÇC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\EventAdministrator\EventAdministratorDeleteHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
EventAdministrator, >
{ 
public 

class +
EventAdministratorDeleteHandler 0
:1 2
IRequestHandler3 B
<B C+
EventAdministratorDeleteRequestC b
,b c-
 EventAdministratorDeleteResponse	d Ñ
>
Ñ Ö
{ 
private 
readonly )
IEventAdministratorRepository 6)
_EventAdministratorRepository7 T
;T U
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
ValidateIntegrity *
validateIntegrity+ <
;< =
public +
EventAdministratorDeleteHandler .
(. /)
IEventAdministratorRepository )(
EventAdministratorRepository* F
,F G
IMapper 
mapper 
, 
ValidateIntegrity 
validateIntegrity 0
)0 1
{ 	
this 
. )
_EventAdministratorRepository .
=/ 0(
EventAdministratorRepository1 M
;M N
this 
. 
_mapper 
= 
mapper !
;! "
this 
. 
validateIntegrity "
=# $
validateIntegrity% 6
;6 7
} 	
public   
async   
Task   
<   ,
 EventAdministratorDeleteResponse   :
>  : ;
Handle  < B
(  B C+
EventAdministratorDeleteRequest  C b
request  c j
,  j k
CancellationToken  l }
cancellationToken	  ~ è
)
  è ê
{!! 	
var## 
events## 
=## 
await## 
validateIntegrity## 0
.##0 1
ValidateEvent##1 >
(##> ?
request##? F
.##F G
IdEvent##G N
)##N O
;##O P
var%% %
isUserCurrentCreatorEvent%% )
=%%* +
events%%, 2
.%%2 3
IdUser%%3 9
==%%: <
request%%= D
.%%D E
UserContext%%E P
.%%P Q
Id%%Q S
;%%S T
if&& 
(&& 
!&& %
isUserCurrentCreatorEvent&& *
)&&* +
throw'' 
new'' 
CustomException'' )
('') *
Models''* 0
.''0 1
Enums''1 6
.''6 7
MessageCodesApi''7 F
.''F G
IncorrectData''G T
,''T U
Models''V \
.''\ ]
Enums''] b
.''b c
ResponseType''c o
.''o p
Error''p u
,''u v
System''w }
.''} ~
Net	''~ Å
.
''Å Ç
HttpStatusCode
''Ç ê
.
''ê ë
Conflict
''ë ô
,
''ô ö
$str(( N
)((N O
;((O P
var** 
isUserAdministrator** #
=**$ %
events**& ,
.**, -"
ListEventAdministrator**- C
.**C D
ToList**D J
(**J K
)**K L
.**L M
Exists**M S
(**S T
e**T U
=>**V X
e**Y Z
.**Z [
IdUser**[ a
==**b d
request**e l
.**l m
IdUser**m s
)**s t
;**t u
if++ 
(++ 
!++ 
isUserAdministrator++ $
)++$ %
throw,, 
new,, 
CustomException,, )
(,,) *
Models,,* 0
.,,0 1
Enums,,1 6
.,,6 7
MessageCodesApi,,7 F
.,,F G
IncorrectData,,G T
,,,T U
Models,,V \
.,,\ ]
Enums,,] b
.,,b c
ResponseType,,c o
.,,o p
Error,,p u
,,,u v
System,,w }
.,,} ~
Net	,,~ Å
.
,,Å Ç
HttpStatusCode
,,Ç ê
.
,,ê ë
Conflict
,,ë ô
,
,,ô ö
$"-- :
.No existe registrado el administrador con Id: -- @
{--@ A
request--A H
.--H I
IdUser--I O
}--O P
 en el evento--P ]
"--] ^
)--^ _
;--_ `
var// %
isUserAdministratorActive// )
=//* +
events//, 2
.//2 3"
ListEventAdministrator//3 I
.//I J
FirstOrDefault//J X
(//X Y
e//Y Z
=>//[ ]
e//^ _
.//_ `
IdUser//` f
==//g i
request//j q
.//q r
IdUser//r x
)//x y
.//y z
State//z 
;	// Ä
if00 
(00 
!00 %
isUserAdministratorActive00 *
)00* +
throw11 
new11 
CustomException11 )
(11) *
Models11* 0
.110 1
Enums111 6
.116 7
MessageCodesApi117 F
.11F G
IncorrectData11G T
,11T U
Models11V \
.11\ ]
Enums11] b
.11b c
ResponseType11c o
.11o p
Error11p u
,11u v
System11w }
.11} ~
Net	11~ Å
.
11Å Ç
HttpStatusCode
11Ç ê
.
11ê ë
Conflict
11ë ô
,
11ô ö
$"22 7
+El administrador a se encuentra desactivado22 =
"22= >
)22> ?
;22? @
var44 $
updateEventAdministrator44 (
=44) *
events44+ 1
.441 2"
ListEventAdministrator442 H
.44H I
FirstOrDefault44I W
(44W X
e44X Y
=>44Z \
e44] ^
.44^ _
IdUser44_ e
==44f h
request44i p
.44p q
IdUser44q w
)44w x
;44x y$
updateEventAdministrator55 $
.55$ %
State55% *
=55+ ,
false55- 2
;552 3$
updateEventAdministrator66 $
.66$ %
Date66% )
=66* +
DateTime66, 4
.664 5
Now665 8
;668 9
var77 
isUpdate77 
=77 
await77  )
_EventAdministratorRepository77! >
.77> ?
Update77? E
(77E F$
updateEventAdministrator77F ^
)77^ _
;77_ `
if88 
(88 
!88 
isUpdate88 
)88 
throw99 
new99 
CustomException99 )
(99) *
Models99* 0
.990 1
Enums991 6
.996 7
MessageCodesApi997 F
.99F G
NotUpdateRecord99G V
,99V W
Models99X ^
.99^ _
Enums99_ d
.99d e
ResponseType99e q
.99q r
Error99r w
,99w x
System99y 
.	99 Ä
Net
99Ä É
.
99É Ñ
HttpStatusCode
99Ñ í
.
99í ì!
InternalServerError
99ì ¶
)
99¶ ß
;
99ß ®
return:: 
_mapper:: 
.:: 
Map:: 
<:: ,
 EventAdministratorDeleteResponse:: ?
>::? @
(::@ A$
updateEventAdministrator::A Y
)::Y Z
;::Z [
};; 	
}>> 
}?? Ô
C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\EventAdministrator\EventAdministratorGetHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
EventAdministrator, >
{ 
public 

class (
EventAdministratorGetHandler -
:. /
IRequestHandler0 ?
<? @(
EventAdministratorGetRequest@ \
,\ ])
EventAdministratorGetResponse^ {
>{ |
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
ValidateIntegrity *
validateIntegrity+ <
;< =
public (
EventAdministratorGetHandler +
(+ ,
IMapper 
mapper 
, 
ValidateIntegrity 
validateIntegrity 0
)0 1
{ 	
this 
. 
_mapper 
= 
mapper !
;! "
this 
. 
validateIntegrity "
=# $
validateIntegrity% 6
;6 7
} 	
public 
async 
Task 
< )
EventAdministratorGetResponse 7
>7 8
Handle9 ?
(? @(
EventAdministratorGetRequest@ \
request] d
,d e
CancellationTokenf w
cancellationToken	x â
)
â ä
{ 	
var 
events 
= 
await 
validateIntegrity 0
.0 1
ValidateEvent1 >
(> ?
request? F
.F G
IdEventG N
)N O
;O P
var!! &
isUserCurrentAdministrator!! *
=!!+ ,
request!!- 4
.!!4 5
UserContext!!5 @
.!!@ A"
ListEventAdministrator!!A W
.!!W X
Exists!!X ^
(!!^ _
e!!_ `
=>!!a c
e!!d e
.!!e f
Id!!f h
==!!i k
events!!l r
.!!r s
Id!!s u
)!!u v
;!!v w
if"" 
("" 
!"" &
isUserCurrentAdministrator"" +
)""+ ,
throw## 
new## 
CustomException## )
(##) *
Models##* 0
.##0 1
Enums##1 6
.##6 7
MessageCodesApi##7 F
.##F G
IncorrectData##G T
,##T U
Models##V \
.##\ ]
Enums##] b
.##b c
ResponseType##c o
.##o p
Error##p u
,##u v
System##w }
.##} ~
Net	##~ Å
.
##Å Ç
HttpStatusCode
##Ç ê
.
##ê ë
Conflict
##ë ô
,
##ô ö
$str$$ S
)$$S T
;$$T U
var&& 
response&& 
=&& 
new&& )
EventAdministratorGetResponse&& <
(&&< =
)&&= >
{'' #
ListEventAdministrators(( '
=((( )
_mapper((* 1
.((1 2
Map((2 5
<((5 6
List((6 :
<((: ;*
EventAdministratorResponseBase((; Y
>((Y Z
>((Z [
((([ \
events((\ b
.((b c"
ListEventAdministrator((c y
)((y z
})) 
;)) 
return** 
response** 
;** 
}++ 	
}.. 
}// Ã:
ÇC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\EventAdministrator\EventAdministratorUpdateHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
EventAdministrator, >
{ 
public 

class +
EventAdministratorUpdateHandler 0
:1 2
IRequestHandler3 B
<B C+
EventAdministratorUpdateRequestC b
,b c-
 EventAdministratorUpdateResponse	d Ñ
>
Ñ Ö
{ 
private 
readonly )
IEventAdministratorRepository 6)
_eventAdministratorRepository7 T
;T U
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
ValidateIntegrity *
validateIntegrity+ <
;< =
public +
EventAdministratorUpdateHandler .
(. /)
IEventAdministratorRepository )(
EventAdministratorRepository* F
,F G
IMapper 
mapper 
, 
ValidateIntegrity 
validateIntegrity /
)/ 0
{ 	
this 
. )
_eventAdministratorRepository .
=/ 0(
EventAdministratorRepository1 M
;M N
this 
. 
_mapper 
= 
mapper !
;! "
this 
. 
validateIntegrity "
=# $
validateIntegrity% 6
;6 7
}   	
public$$ 
async$$ 
Task$$ 
<$$ ,
 EventAdministratorUpdateResponse$$ :
>$$: ;
Handle$$< B
($$B C+
EventAdministratorUpdateRequest$$C b
request$$c j
,$$j k
CancellationToken$$l }
cancellationToken	$$~ è
)
$$è ê
{%% 	
var'' 
events'' 
='' 
await'' 
validateIntegrity'' 0
.''0 1
ValidateEvent''1 >
(''> ?
request''? F
.''F G
IdEvent''G N
)''N O
;''O P
var)) %
isUserCurrentCreatorEvent)) )
=))* +
events)), 2
.))2 3
IdUser))3 9
==)): <
request))= D
.))D E
UserContext))E P
.))P Q
Id))Q S
;))S T
if** 
(** 
!** %
isUserCurrentCreatorEvent** *
)*** +
throw++ 
new++ 
CustomException++ )
(++) *
Models++* 0
.++0 1
Enums++1 6
.++6 7
MessageCodesApi++7 F
.++F G
IncorrectData++G T
,++T U
Models++V \
.++\ ]
Enums++] b
.++b c
ResponseType++c o
.++o p
Error++p u
,++u v
System++w }
.++} ~
Net	++~ Å
.
++Å Ç
HttpStatusCode
++Ç ê
.
++ê ë
Conflict
++ë ô
,
++ô ö
$str,, N
),,N O
;,,O P
var.. 
isUserAdministrator.. #
=..$ %
events..& ,
..., -"
ListEventAdministrator..- C
...C D
ToList..D J
(..J K
)..K L
...L M
Exists..M S
(..S T
e..T U
=>..V X
e..Y Z
...Z [
IdUser..[ a
==..b d
request..e l
...l m
IdUser..m s
)..s t
;..t u
if// 
(// 
!// 
isUserAdministrator// $
)//$ %
throw00 
new00 
CustomException00 )
(00) *
Models00* 0
.000 1
Enums001 6
.006 7
MessageCodesApi007 F
.00F G
IncorrectData00G T
,00T U
Models00V \
.00\ ]
Enums00] b
.00b c
ResponseType00c o
.00o p
Error00p u
,00u v
System00w }
.00} ~
Net	00~ Å
.
00Å Ç
HttpStatusCode
00Ç ê
.
00ê ë
Conflict
00ë ô
,
00ô ö
$"11 :
.No existe registrado el administrador con Id: 11 @
{11@ A
request11A H
.11H I
IdUser11I O
}11O P
 en el evento11P ]
"11] ^
)11^ _
;11_ `
var33 %
isUserAdministratorActive33 )
=33* +
events33, 2
.332 3"
ListEventAdministrator333 I
.33I J
FirstOrDefault33J X
(33X Y
e33Y Z
=>33[ ]
e33^ _
.33_ `
IdUser33` f
==33g i
request33j q
.33q r
IdUser33r x
)33x y
.33y z
State33z 
;	33 Ä
if44 
(44 
!44 %
isUserAdministratorActive44 *
)44* +
throw55 
new55 
CustomException55 )
(55) *
Models55* 0
.550 1
Enums551 6
.556 7
MessageCodesApi557 F
.55F G
IncorrectData55G T
,55T U
Models55V \
.55\ ]
Enums55] b
.55b c
ResponseType55c o
.55o p
Error55p u
,55u v
System55w }
.55} ~
Net	55~ Å
.
55Å Ç
HttpStatusCode
55Ç ê
.
55ê ë
Conflict
55ë ô
,
55ô ö
$"66 :
.El usuario administrador se encuentra Acticado66 @
"66@ A
)66A B
;66B C
var88 $
updateEventAdministrator88 (
=88) *
events88+ 1
.881 2"
ListEventAdministrator882 H
.88H I
FirstOrDefault88I W
(88W X
e88X Y
=>88Z \
e88] ^
.88^ _
IdUser88_ e
==88f h
request88i p
.88p q
IdUser88q w
)88w x
;88x y$
updateEventAdministrator99 $
.99$ %
State99% *
=99+ ,
true99- 1
;991 2$
updateEventAdministrator:: $
.::$ %
Date::% )
=::* +
DateTime::, 4
.::4 5
Now::5 8
;::8 9
var;; 
isUpdate;; 
=;; 
await;;  )
_eventAdministratorRepository;;! >
.;;> ?
Update;;? E
(;;E F$
updateEventAdministrator;;F ^
);;^ _
;;;_ `
if<< 
(<< 
!<< 
isUpdate<< 
)<< 
throw== 
new== 
CustomException== )
(==) *
Models==* 0
.==0 1
Enums==1 6
.==6 7
MessageCodesApi==7 F
.==F G
NotUpdateRecord==G V
,==V W
Models==X ^
.==^ _
Enums==_ d
.==d e
ResponseType==e q
.==q r
Error==r w
,==w x
System==y 
.	== Ä
Net
==Ä É
.
==É Ñ
HttpStatusCode
==Ñ í
.
==í ì!
InternalServerError
==ì ¶
)
==¶ ß
;
==ß ®
return>> 
_mapper>> 
.>> 
Map>> 
<>> ,
 EventAdministratorUpdateResponse>> ?
>>>? @
(>>@ A$
updateEventAdministrator>>A Y
)>>Y Z
;>>Z [
}?? 	
}CC 
}DD Â=
hC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Event\EventCreateHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
Event, 1
{ 
public 

class 
EventCreateHandler #
:$ %
IRequestHandler& 5
<5 6
EventCreateRequest6 H
,H I
EventCreateResponseJ ]
>] ^
{ 
private 
readonly 
IEventRepository )
_eventRepository* :
;: ;
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
ValidateIntegrity *
validateIntegrity+ <
;< =
private 
readonly 
IConfiguration '
configuration( 5
;5 6
public 
EventCreateHandler !
(! "
IEventRepository 
eventRepository (
,( )
IMapper 
mapper 
, 
ValidateIntegrity 
validateIntegrity +
,+ ,
IConfiguration 
configuration $
) 	
{   	
this!! 
.!! 
_eventRepository!! !
=!!" #
eventRepository!!$ 3
;!!3 4
this"" 
."" 
_mapper"" 
="" 
mapper"" !
;""! "
this## 
.## 
validateIntegrity## "
=### $
validateIntegrity##% 6
;##6 7
this$$ 
.$$ 
configuration$$ 
=$$  
configuration$$! .
;$$. /
}%% 	
public(( 
async(( 
Task(( 
<(( 
EventCreateResponse(( -
>((- .
Handle((/ 5
(((5 6
EventCreateRequest((6 H
request((I P
,((P Q
CancellationToken((R c
cancellationToken((d u
)((u v
{)) 	
var++ 
userCurrent++ 
=++ 
await++ #
validateIntegrity++$ 5
.++5 6
ValidateUser++6 B
(++B C
request++C J
)++J K
;++K L
var-- 
events-- 
=-- 
await-- 
_eventRepository-- /
.--/ 0
GetAsync--0 8
(--8 9
e--9 :
=>--; =
e--> ?
.--? @
IdUser--@ F
==--G I
userCurrent--J U
.--U V
Id--V X
&&--Y [
!--\ ]
e--] ^
.--^ _
IsDelete--_ g
)--g h
;--h i
if.. 
(.. 
events.. 
... 
Count.. 
(.. 
).. 
>=.. !
userCurrent.." -
...- .
EventNumber... 9
...9 :
NumberMaxEvent..: H
)..H I
throw// 
new// 
CustomException// )
(//) *
Models//* 0
.//0 1
Enums//1 6
.//6 7
MessageCodesApi//7 F
.//F G
MaxEventAllow//G T
,//T U
Models//V \
.//\ ]
Enums//] b
.//b c
ResponseType//c o
.//o p
Error//p u
,//u v
System//w }
.//} ~
Net	//~ Å
.
//Å Ç
HttpStatusCode
//Ç ê
.
//ê ë

BadRequest
//ë õ
)
//õ ú
;
//ú ù
if11 
(11 
request11 
.11 
	MaxPeople11 !
&&11" $
request11% ,
.11, -
NumberMaxCandidate11- ?
<=11@ B
$num11C D
)11D E
throw22 
new22 
CustomException22 )
(22) *
Models22* 0
.220 1
Enums221 6
.226 7
MessageCodesApi227 F
.22F G
MaxPeopleEvent22G U
,22U V
Models22W ]
.22] ^
Enums22^ c
.22c d
ResponseType22d p
.22p q
Error22q v
,22v w
System22x ~
.22~ 
Net	22 Ç
.
22Ç É
HttpStatusCode
22É ë
.
22ë í

BadRequest
22í ú
)
22ú ù
;
22ù û
if33 
(33 
events33 
.33 
Any33 
(33 
e33 
=>33 
e33  !
.33! "
Name33" &
==33' )
request33* 1
.331 2
Name332 6
)336 7
)337 8
throw44 
new44 
CustomException44 )
(44) *
Models44* 0
.440 1
Enums441 6
.446 7
MessageCodesApi447 F
.44F G
EventRegistered44G V
,44V W
Models44X ^
.44^ _
Enums44_ d
.44d e
ResponseType44e q
.44q r
Error44r w
,44w x
System44y 
.	44 Ä
Net
44Ä É
.
44É Ñ
HttpStatusCode
44Ñ í
.
44í ì

BadRequest
44ì ù
)
44ù û
;
44û ü
var55 
newEvent55 
=55 
_mapper55 "
.55" #
Map55# &
<55& '
Models55' -
.55- .

Persitence55. 8
.558 9
Event559 >
>55> ?
(55? @
request55@ G
)55G H
;55H I
newEvent77 
.77 
UserCreator77  
=77! "
userCurrent77# .
;77. /
newEvent99 
.99 "
ListEventAdministrator99 +
=99, -
new99. 1
List992 6
<996 7
Models997 =
.99= >

Persitence99> H
.99H I
EventAdministrator99I [
>99[ \
(99\ ]
)99] ^
{:: 
new;; 
Models;; 
.;; 

Persitence;; %
.;;% &
EventAdministrator;;& 8
(;;8 9
);;9 :
{;;: ;
Event<< 
=<< 
newEvent<< 
,<<  
User== 
=== 
userCurrent== "
}>> 
}?? 
;?? 
newEventAA 
.AA 
	CodeEventAA 
=AA  
CommonAA! '
.AA' (
UtilAA( ,
.AA, -
GenerateCodeAA- 9
(AA9 :
ConvertAA: A
.AAA B
ToInt32AAB I
(AAI J
configurationAAJ W
.AAW X

GetSectionAAX b
(AAb c
$strAAc x
)AAx y
.AAy z
ValueAAz 
)	AA Ä
)
AAÄ Å
;
AAÅ Ç
varCC 
	hasCreateCC 
=CC 
awaitCC !
_eventRepositoryCC" 2
.CC2 3
CreateAsyncCC3 >
(CC> ?
newEventCC? G
)CCG H
;CCH I
ifEE 
(EE 
!EE 
	hasCreateEE 
)EE 
throwFF 
newFF 
CustomExceptionFF )
(FF) *
ModelsFF* 0
.FF0 1
EnumsFF1 6
.FF6 7
MessageCodesApiFF7 F
.FFF G
NotCreateRecordFFG V
,FFV W
ModelsFFX ^
.FF^ _
EnumsFF_ d
.FFd e
ResponseTypeFFe q
.FFq r
ErrorFFr w
,FFw x
SystemFFy 
.	FF Ä
Net
FFÄ É
.
FFÉ Ñ
HttpStatusCode
FFÑ í
.
FFí ì!
InternalServerError
FFì ¶
)
FF¶ ß
;
FFß ®
varGG 
responseEventGG 
=GG 
_mapperGG  '
.GG' (
MapGG( +
<GG+ ,
EventCreateResponseGG, ?
>GG? @
(GG@ A
newEventGGA I
)GGI J
;GGJ K
returnHH 
responseEventHH  
;HH  !
}II 	
}KK 
}LL ø#
hC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Event\EventDeleteHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
Event, 1
{ 
public 

class 
EventDeleteHandler #
:$ %
IRequestHandler& 5
<5 6
EventDeleteRequest6 H
,H I
EventDeleteResponseJ ]
>] ^
{ 
private 
readonly 
IEventRepository )
_eventRepository* :
;: ;
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
ValidateIntegrity *
validateIntegrity+ <
;< =
public 
EventDeleteHandler !
(! "
IEventRepository 
eventRepository ,
,, -
IMapper 
mapper 
, 
ValidateIntegrity 
validateIntegrity /
)/ 0
{ 	
this 
. 
_eventRepository !
=" #
eventRepository$ 3
;3 4
this 
. 
_mapper 
= 
mapper !
;! "
this 
. 
validateIntegrity "
=# $
validateIntegrity% 6
;6 7
} 	
public   
async   
Task   
<   
EventDeleteResponse   -
>  - .
Handle  / 5
(  5 6
EventDeleteRequest  6 H
request  I P
,  P Q
CancellationToken  R c
cancellationToken  d u
)  u v
{!! 	
var## 
eventCurrent## 
=## 
await## $
validateIntegrity##% 6
.##6 7
ValidateEvent##7 D
(##D E
request##E L
.##L M
Id##M O
)##O P
;##P Q
var%% %
isUserCurrentCreatorEvent%% )
=%%* +
eventCurrent%%, 8
.%%8 9
IdUser%%9 ?
==%%@ B
request%%C J
.%%J K
UserContext%%K V
.%%V W
Id%%W Y
;%%Y Z
if&& 
(&& 
!&& %
isUserCurrentCreatorEvent&& *
)&&* +
throw'' 
new'' 
CustomException'' )
('') *
Models''* 0
.''0 1
Enums''1 6
.''6 7
MessageCodesApi''7 F
.''F G
EventCreator''G S
,''S T
Models''U [
.''[ \
Enums''\ a
.''a b
ResponseType''b n
.''n o
Error''o t
,''t u
System''v |
.''| }
Net	''} Ä
.
''Ä Å
HttpStatusCode
''Å è
.
''è ê
Conflict
''ê ò
)
''ò ô
;
''ô ö
eventCurrent(( 
.(( 
IsDelete(( !
=((" #
true(($ (
;((( )
eventCurrent)) 
.)) 
Name)) 
=)) 
$"))  "
{))" #
eventCurrent))# /
.))/ 0
Name))0 4
}))4 5
_))5 6
{))6 7
DateTime))7 ?
.))? @
Now))@ C
}))C D
_Delete))D K
"))K L
;))L M
var** 
responseDelete** 
=**  
await**! &
_eventRepository**' 7
.**7 8
Update**8 >
(**> ?
eventCurrent**? K
)**K L
;**L M
if,, 
(,, 
!,, 
responseDelete,, 
),,  
throw-- 
new-- 
CustomException-- )
(--) *
Models--* 0
.--0 1
Enums--1 6
.--6 7
MessageCodesApi--7 F
.--F G
NotDeleteRecord--G V
,--V W
Models--X ^
.--^ _
Enums--_ d
.--d e
ResponseType--e q
.--q r
Error--r w
,--w x
System--y 
.	-- Ä
Net
--Ä É
.
--É Ñ
HttpStatusCode
--Ñ í
.
--í ì!
InternalServerError
--ì ¶
)
--¶ ß
;
--ß ®
return.. 
_mapper.. 
... 
Map.. 
<.. 
EventDeleteResponse.. 2
>..2 3
(..3 4
eventCurrent..4 @
)..@ A
;..A B
}// 	
}11 
}22 ë
eC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Event\EventGetHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
Event, 1
{ 
public 

class 
EventGetHandler  
:! "
IRequestHandler# 2
<2 3
EventGetRequest3 B
,B C
EventGetResponseD T
>T U
{ 
private 
readonly 
IEventRepository )
_eventRepository* :
;: ;
private 
readonly 
IMapper  
_mapper! (
;( )
public 
EventGetHandler 
( 
IEventRepository 
eventRepository ,
,, -
IMapper 
mapper 
) 
{ 	
this 
. 
_eventRepository !
=" #
eventRepository$ 3
;3 4
this 
. 
_mapper 
= 
mapper !
;! "
} 	
public 
async 
Task 
< 
EventGetResponse *
>* +
Handle, 2
(2 3
EventGetRequest3 B
requestC J
,J K
CancellationTokenL ]
cancellationToken^ o
)o p
{ 	
List 
< 
Models 
. 

Persitence "
." #
Event# (
>( )

listEvents* 4
;4 5
if   
(   
request   
.   
Id   
!=   
null   "
)  " #

listEvents!! 
=!! 
(!! 
await!! #
_eventRepository!!$ 4
.!!4 5
GetAsync!!5 =
(!!= >
e!!> ?
=>!!@ B
e!!C D
.!!D E
Id!!E G
==!!H J
request!!K R
.!!R S
Id!!S U
)!!U V
)!!V W
.!!W X
ToList!!X ^
(!!^ _
)!!_ `
;!!` a
else"" 

listEvents## 
=## 
(## 
await## #
_eventRepository##$ 4
.##4 5
GetAsync##5 =
(##= >
)##> ?
)##? @
.##@ A
ToList##A G
(##G H
)##H I
;##I J
var$$ 
response$$ 
=$$ 

listEvents$$ &
.$$& '
OrderByDescending$$' 8
($$8 9
e$$9 :
=>$$; =
e$$> ?
.$$? @
Id$$@ B
)$$B C
.%% 
Skip%% 
(%% 
request%% 
.%% 
Offset%%  
)%%  !
.&& 
Take&& 
(&& 
request&& 
.&& 
Limit&& 
)&&  
.'' 
ToList'' 
('' 
)'' 
;'' 
return(( 
new(( 
EventGetResponse(( '
(((' (
)((( )
{)) 

ListEvents** 
=** 
_mapper** $
.**$ %
Map**% (
<**( )
List**) -
<**- .
EventResponseBase**. ?
>**? @
>**@ A
(**A B
response**B J
)**J K
}++ 
;++ 
},, 	
}// 
}00 ´K
hC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Event\EventUpdateHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
Event, 1
{ 
public 

class 
EventUpdateHandler #
:$ %
IRequestHandler& 5
<5 6
EventUpdateRequest6 H
,H I
EventUpdateResponseJ ]
>] ^
{ 
private 
readonly 
IEventRepository )
_eventRepository* :
;: ;
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IUserRepository (
userRepository) 7
;7 8
private 
readonly 
ValidateIntegrity *
validateIntegrity+ <
;< =
public 
EventUpdateHandler !
(! "
IEventRepository 
eventRepository ,
,, -
IMapper 
mapper 
, 
IUserRepository 
userRepository *
,* +
ValidateIntegrity 
validateIntegrity /
)/ 0
{ 	
this 
. 
_eventRepository !
=" #
eventRepository$ 3
;3 4
this 
. 
_mapper 
= 
mapper !
;! "
this   
.   
userRepository   
=    !
userRepository  " 0
;  0 1
this!! 
.!! 
validateIntegrity!! "
=!!# $
validateIntegrity!!% 6
;!!6 7
}"" 	
public&& 
async&& 
Task&& 
<&& 
EventUpdateResponse&& -
>&&- .
Handle&&/ 5
(&&5 6
EventUpdateRequest&&6 H
request&&I P
,&&P Q
CancellationToken&&R c
cancellationToken&&d u
)&&u v
{'' 	
var)) 
eventCurrent)) 
=)) 
await)) $
validateIntegrity))% 6
.))6 7
ValidateEvent))7 D
())D E
request))E L
.))L M
Id))M O
.))O P
Value))P U
)))U V
;))V W
var++ 
isUserAdministrator++ #
=++$ %
eventCurrent++& 2
.++2 3"
ListEventAdministrator++3 I
.++I J
Count++J O
(++O P
e++P Q
=>++R T
e++U V
.++V W
IdUser++W ]
==++^ `
request++a h
.++h i
UserContext++i t
.++t u
Id++u w
)++w x
;++x y
if,, 
(,, 
isUserAdministrator,, #
==,,$ &
$num,,' (
),,( )
throw-- 
new-- 
CustomException-- )
(--) *
Models--* 0
.--0 1
Enums--1 6
.--6 7
MessageCodesApi--7 F
.--F G
IncorrectData--G T
,--T U
Models--V \
.--\ ]
Enums--] b
.--b c
ResponseType--c o
.--o p
Error--p u
,--u v
System--w }
.--} ~
Net	--~ Å
.
--Å Ç
HttpStatusCode
--Ç ê
.
--ê ë
NotFound
--ë ô
,
--ô ö
$".., .
El usuario con Id: ... A
{..A B
request..B I
...I J
UserContext..J U
...U V
Id..V X
}..X Y/
# no es administrador en el evento: ..Y |
{..| }
eventCurrent	..} â
.
..â ä
Name
..ä é
}
..é è
"
..è ê
)
..ê ë
;
..ë í
var00 
administratorEvent00 "
=00# $
await00% *
userRepository00+ 9
.009 :
GetByIdAsync00: F
(00F G
eventCurrent00G S
.00S T
IdUser00T Z
)00Z [
;00[ \
if11 
(11 
administratorEvent11 "
==11# %
null11& *
)11* +
throw22 
new22 
CustomException22 )
(22) *
Models22* 0
.220 1
Enums221 6
.226 7
MessageCodesApi227 F
.22F G
ErrorGeneric22G S
,22S T
Models22U [
.22[ \
Enums22\ a
.22a b
ResponseType22b n
.22n o
Error22o t
,22t u
System22v |
.22| }
Net	22} Ä
.
22Ä Å
HttpStatusCode
22Å è
.
22è ê!
InternalServerError
22ê £
,
22£ §
$"33/ 1*
El creador del evento con ID: 331 O
{33O P
eventCurrent33P \
.33\ ]
Id33] _
}33_ `%
 no es el Usuario con Id:33` y
{33y z
eventCurrent	33z Ü
.
33Ü á
IdUser
33á ç
}
33ç é
"
33é è
)
33è ê
;
33ê ë
var55 
nameEventExist55 
=55  
(55! "
await55" '
_eventRepository55( 8
.558 9
GetAsync559 A
(55A B
e55B C
=>55D F
e55I J
.55J K
IdUser55K Q
==55R T
administratorEvent55U g
.55g h
Id55h j
&&66H J
e66K L
.66L M
Name66M Q
==66R T
request66U \
.66\ ]
Name66] a
)66a b
)66b c
.66c d
FirstOrDefault66d r
(66r s
)66s t
;66t u
if77 
(77 
nameEventExist77 
!=77 
null77 #
&&77$ &
nameEventExist77' 5
.775 6
Id776 8
!=778 :
eventCurrent77: F
.77F G
Id77G I
)77I J
throw88 
new88 
CustomException88 +
(88+ ,
Models88, 2
.882 3
Enums883 8
.888 9
MessageCodesApi889 H
.88H I
EventRegistered88I X
,88X Y
Models88Z `
.88` a
Enums88a f
.88f g
ResponseType88g s
.88s t
Error88t y
,88y z
System	88{ Å
.
88Å Ç
Net
88Ç Ö
.
88Ö Ü
HttpStatusCode
88Ü î
.
88î ï!
InternalServerError
88ï ®
)
88® ©
;
88© ™
if:: 
(:: 
request:: 
.:: 
	MaxPeople:: !
&&::" $
request::% ,
.::, -
NumberMaxCandidate::- ?
<=::@ B
$num::C D
)::D E
throw;; 
new;; 
CustomException;; -
(;;- .
Models;;. 4
.;;4 5
Enums;;5 :
.;;: ;
MessageCodesApi;;; J
.;;J K
MaxPeopleEvent;;K Y
,;;Y Z
Models;;[ a
.;;a b
Enums;;b g
.;;g h
ResponseType;;h t
.;;t u
Error;;u z
,;;z {
System	;;| Ç
.
;;Ç É
Net
;;É Ü
.
;;Ü á
HttpStatusCode
;;á ï
.
;;ï ñ

BadRequest
;;ñ †
)
;;† °
;
;;° ¢
eventCurrent== 
.== 
Category== !
===" #
request==$ +
.==+ ,
Category==, 4
;==4 5
eventCurrent>> 
.>> 
Description>> $
=>>% &
request>>' .
.>>. /
Description>>/ :
;>>: ;
eventCurrent?? 
.?? 
Image?? 
=??  
request??! (
.??( )
Description??) 4
;??4 5
eventCurrent@@ 
.@@ 
IsActive@@ !
=@@" #
request@@$ +
.@@+ ,
IsActive@@, 4
;@@4 5
eventCurrentAA 
.AA 
	MaxPeopleAA "
=AA# $
requestAA% ,
.AA, -
	MaxPeopleAA- 6
;AA6 7
eventCurrentBB 
.BB 
NameBB 
=BB 
requestBB  '
.BB' (
NameBB( ,
;BB, -
eventCurrentCC 
.CC 
NumberMaxCandidateCC +
=CC, -
requestCC. 5
.CC5 6
NumberMaxCandidateCC6 H
;CCH I
eventCurrentDD 
.DD 
NumberMaxPeopleDD (
=DD) *
requestDD+ 2
.DD2 3
NumberMaxPeopleDD3 B
;DDB C
varFF 
isUpdateFF 
=FF 
awaitFF  
_eventRepositoryFF! 1
.FF1 2
UpdateFF2 8
(FF8 9
eventCurrentFF9 E
)FFE F
;FFF G
ifGG 
(GG 
!GG 
isUpdateGG 
)GG 
throwHH 
newHH 
CustomExceptionHH )
(HH) *
ModelsHH* 0
.HH0 1
EnumsHH1 6
.HH6 7
MessageCodesApiHH7 F
.HHF G
NotUpdateRecordHHG V
,HHV W
ModelsHHX ^
.HH^ _
EnumsHH_ d
.HHd e
ResponseTypeHHe q
.HHq r
ErrorHHr w
,HHw x
SystemHHy 
.	HH Ä
Net
HHÄ É
.
HHÉ Ñ
HttpStatusCode
HHÑ í
.
HHí ì!
InternalServerError
HHì ¶
)
HH¶ ß
;
HHß ®
returnII 
_mapperII 
.II 
MapII 
<II 
EventUpdateResponseII 2
>II2 3
(II3 4
eventCurrentII4 @
)II@ A
;IIA B
}JJ 	
}NN 
}OO ≈
jC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\User\ChangePasswordHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
User, 0
{ 
public 

class !
ChangePasswordHandler &
:' (
IRequestHandler) 8
<8 9!
ChangePasswordRequest9 N
,N O
UnitP T
>T U
{ 
private 
readonly 
IUserRepository (
userRepository) 7
;7 8
private 
readonly 
IConfiguration '
_configuration( 6
;6 7
private 
readonly 
ValidateIntegrity *
validateIntegrity+ <
;< =
public !
ChangePasswordHandler $
($ %
IUserRepository 
userRepository *
,* +
IConfiguration 
configuration (
,( )
ValidateIntegrity 
validateIntegrity /
)/ 0
{ 	
this 
. 
userRepository 
=  !
userRepository" 0
;0 1
_configuration 
= 
configuration *
;* +
this 
. 
validateIntegrity "
=# $
validateIntegrity% 6
;6 7
} 	
public!! 
async!! 
Task!! 
<!! 
Unit!! 
>!! 
Handle!!  &
(!!& '!
ChangePasswordRequest!!' <
request!!= D
,!!D E
CancellationToken!!F W
cancellationToken!!X i
)!!i j
{"" 	
var## 

_secretKey## 
=## 
_configuration## +
.##+ ,

GetSection##, 6
(##6 7
$str##7 B
)##B C
.##C D
Value##D I
;##I J
var%% 
userCurrent%% 
=%% 
await%% #
validateIntegrity%%$ 5
.%%5 6
ValidateUser%%6 B
(%%B C
request%%C J
)%%J K
;%%K L
var'' 
newPassword'' 
='' 
Common'' $
.''$ %
Util''% )
.'') *
ComputeSHA256''* 7
(''7 8
request''8 ?
.''? @
NewPassword''@ K
,''K L

_secretKey''M W
)''W X
;''X Y
userCurrent)) 
.)) 
Password))  
=))! "
newPassword))# .
;)). /
var** 
isUserUpdate** 
=** 
await** $
userRepository**% 3
.**3 4
Update**4 :
(**: ;
userCurrent**; F
)**F G
;**G H
if++ 
(++ 
!++ 
isUserUpdate++ 
)++ 
throw,, 
new,, 
CustomException,, )
(,,) *
Models,,* 0
.,,0 1
Enums,,1 6
.,,6 7
MessageCodesApi,,7 F
.,,F G
NotUpdateRecord,,G V
,,,V W
Models,,X ^
.,,^ _
Enums,,_ d
.,,d e
ResponseType,,e q
.,,q r
Error,,r w
,,,w x
System,,y 
.	,, Ä
Net
,,Ä É
.
,,É Ñ
HttpStatusCode
,,Ñ í
.
,,í ì!
InternalServerError
,,ì ¶
)
,,¶ ß
;
,,ß ®
return-- 
Unit-- 
.-- 
Value-- 
;-- 
}.. 	
}00 
}11 ˚/
jC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\User\IncreaseEventsHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
User, 0
{ 
public 

class !
IncreaseEventsHandler &
:' (
IRequestHandler) 8
<8 9!
IncreaseEventsRequest9 N
,N O
UnitP T
>T U
{ 
private 
readonly 
ILogger  
<  !
UserCreateHandler! 2
>2 3
logger4 :
;: ;
private 
readonly 
IUserRepository (
userRepository) 7
;7 8
private 
readonly 
IConfiguration '
_configuration( 6
;6 7
private 
readonly 
ValidateIntegrity *
validateIntegrity+ <
;< =
public !
IncreaseEventsHandler $
($ %
ILogger 
< 
UserCreateHandler %
>% &
logger' -
,- .
IUserRepository 
userRepository *
,* +
IConfiguration 
configuration (
,( )
ValidateIntegrity 
validateIntegrity /
)/ 0
{ 	
this 
. 
logger 
= 
logger  
;  !
this 
. 
userRepository 
=  !
userRepository" 0
;0 1
_configuration   
=   
configuration   *
;  * +
this!! 
.!! 
validateIntegrity!! "
=!!# $
validateIntegrity!!% 6
;!!6 7
}"" 	
public&& 
async&& 
Task&& 
<&& 
Unit&& 
>&& 
Handle&&  &
(&&& '!
IncreaseEventsRequest&&' <
request&&= D
,&&D E
CancellationToken&&F W
cancellationToken&&X i
)&&i j
{'' 	
await)) 
validateIntegrity)) #
.))# $
ValidateUser))$ 0
())0 1
request))1 8
)))8 9
;))9 :
var++ 
userService++ 
=++ 
_configuration++ ,
.++, -

GetSection++- 7
(++7 8
$str++8 K
)++K L
.++L M
Value++M R
;++R S
var,, 
passwordService,, 
=,,  !
_configuration,," 0
.,,0 1

GetSection,,1 ;
(,,; <
$str,,< S
),,S T
.,,T U
Value,,U Z
;,,Z [
var-- 

_secretKey-- 
=-- 
_configuration-- +
.--+ ,

GetSection--, 6
(--6 7
$str--7 B
)--B C
.--C D
Value--D I
;--I J
var.. 
passHash.. 
=.. 
Common.. !
...! "
Util.." &
...& '
ComputeSHA256..' 4
(..4 5
request..5 <
...< =
PasswordToService..= N
,..N O

_secretKey..P Z
)..Z [
;..[ \
if// 
(// 
!// 
(// 
userService// 
==//  
request//! (
.//( )
UserToService//) 6
&&//7 9
passHash//: B
==//C E
passwordService//F U
)//U V
)//V W
throw00 
new00 
CustomException00 )
(00) *
Models00* 0
.000 1
Enums001 6
.006 7
MessageCodesApi007 F
.00F G
NotAuthorization00G W
,00W X
Models00Y _
.00_ `
Enums00` e
.00e f
ResponseType00f r
.00r s
Error00s x
,00x y
System	00z Ä
.
00Ä Å
Net
00Å Ñ
.
00Ñ Ö
HttpStatusCode
00Ö ì
.
00ì î
Unauthorized
00î †
)
00† °
;
00° ¢
var22  
userToIncreaseEvents22 $
=22% &
await22' ,
validateIntegrity22- >
.22> ?
ValidateUser22? K
(22K L
request22L S
.22S T!
IdUserToIncreaseEvent22T i
)22i j
;22j k 
userToIncreaseEvents33  
.33  !
EventNumber33! ,
.33, -
NumberMaxEvent33- ;
=33< =
request33> E
.33E F
NumberEvent33F Q
;33Q R
var55 
isUserUpdate55 
=55 
await55 $
userRepository55% 3
.553 4
Update554 :
(55: ; 
userToIncreaseEvents55; O
)55O P
;55P Q
if66 
(66 
!66 
isUserUpdate66 
)66 
throw77 
new77 
CustomException77 )
(77) *
Models77* 0
.770 1
Enums771 6
.776 7
MessageCodesApi777 F
.77F G
NotUpdateRecord77G V
,77V W
Models77X ^
.77^ _
Enums77_ d
.77d e
ResponseType77e q
.77q r
Error77r w
,77w x
System77y 
.	77 Ä
Net
77Ä É
.
77É Ñ
HttpStatusCode
77Ñ í
.
77í ì!
InternalServerError
77ì ¶
)
77¶ ß
;
77ß ®
logger88 
.88 
LogInformation88 !
(88! "
$"88" $2
&Se actualiz√≥ los eventos del usuario 88$ I
{88I J 
userToIncreaseEvents88J ^
.88^ _
UserName88_ g
}88g h
 a: 88h l
{88l m!
userToIncreaseEvents	88m Å
.
88Å Ç
EventNumber
88Ç ç
.
88ç é
NumberMaxEvent
88é ú
}
88ú ù
 Eventos
88ù •
"
88• ¶
)
88¶ ß
;
88ß ®
return99 
Unit99 
.99 
Value99 
;99 
}:: 	
}<< 
}== â,
fC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\User\UserCreateHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
User, 0
{ 
public 

class 
UserCreateHandler "
:# $
IRequestHandler% 4
<4 5
UserCreateRequest5 F
,F G
UserCreateResponseH Z
>Z [
{ 
private 
readonly 
ILogger  
<  !
UserCreateHandler! 2
>2 3
logger4 :
;: ;
private 
readonly 
IUserRepository (
userRepository) 7
;7 8
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
IConfiguration '
_configuration( 6
;6 7
public 
UserCreateHandler  
(  !
ILogger 
< 
UserCreateHandler %
>% &
logger' -
,- .
IUserRepository 
userRepository *
,* +
IMapper 
mapper 
, 
IConfiguration 
configuration (
)( )
{ 	
this 
. 
logger 
= 
logger  
;  !
this 
. 
userRepository 
=  !
userRepository" 0
;0 1
this 
. 
mapper 
= 
mapper  
;  !
_configuration   
=   
configuration   *
;  * +
}"" 	
public&& 
async&& 
Task&& 
<&& 
UserCreateResponse&& ,
>&&, -
Handle&&. 4
(&&4 5
UserCreateRequest&&5 F
request&&G N
,&&N O
CancellationToken&&P a
cancellationToken&&b s
)&&s t
{'' 	
var(( 

_secretKey(( 
=(( 
_configuration(( +
.((+ ,

GetSection((, 6
(((6 7
$str((7 B
)((B C
.((C D
Value((D I
;((I J
request** 
.** 
Password** 
=** 
Common** %
.**% &
Util**& *
.*** +
ComputeSHA256**+ 8
(**8 9
request**9 @
.**@ A
Password**A I
,**I J

_secretKey**K U
)**U V
;**V W
var,, 

emailExist,, 
=,, 
await,, "
userRepository,,# 1
.,,1 2
GetAsync,,2 :
(,,: ;
u,,; <
=>,,= ?
u,,@ A
.,,A B
Email,,B G
==,,H J
request,,K R
.,,R S
Email,,S X
),,X Y
;,,Y Z
if-- 
(-- 

emailExist-- 
.-- 
Any-- 
(-- 
)--  
)--  !
throw.. 
new.. 
CustomException.. )
(..) *
Models..* 0
...0 1
Enums..1 6
...6 7
MessageCodesApi..7 F
...F G
EmailRegistered..G V
,..V W
Models..X ^
...^ _
Enums.._ d
...d e
ResponseType..e q
...q r
Error..r w
,..w x
System..y 
.	.. Ä
Net
..Ä É
.
..É Ñ
HttpStatusCode
..Ñ í
.
..í ì
Conflict
..ì õ
)
..õ ú
;
..ú ù
var// 
userNew// 
=// 
mapper//  
.//  !
Map//! $
<//$ %
Models//% +
.//+ ,

Persitence//, 6
.//6 7
User//7 ;
>//; <
(//< =
request//= D
)//D E
;//E F
userNew00 
.00 
EventNumber00 
=00  !
new00" %
Models00& ,
.00, -

Persitence00- 7
.007 8
EventNumber008 C
(00C D
)00D E
{11 
User22 
=22 
userNew22 
}33 
;33 
userNew44 
.44 
IsActive44 
=44 
true44 #
;44# $
var55 

isRegister55 
=55 
await55 "
userRepository55# 1
.551 2
CreateAsync552 =
(55= >
userNew55> E
)55E F
;55F G
if66 
(66 
!66 

isRegister66 
)66 
throw77 
new77 
CustomException77 )
(77) *
Models77* 0
.770 1
Enums771 6
.776 7
MessageCodesApi777 F
.77F G
NotCreateRecord77G V
,77V W
Models77X ^
.77^ _
Enums77_ d
.77d e
ResponseType77e q
.77q r
Error77r w
,77w x
System77y 
.	77 Ä
Net
77Ä É
.
77É Ñ
HttpStatusCode
77Ñ í
.
77í ì!
InternalServerError
77ì ¶
)
77¶ ß
;
77ß ®
logger88 
.88 
LogInformation88 !
(88! "
$str88" <
)88< =
;88= >
return99 
mapper99 
.99 
Map99 
<99 
UserCreateResponse99 0
>990 1
(991 2
userNew992 9
)999 :
;99: ;
}:: 	
}<< 
}== §4
fC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\User\UserDeleteHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
User, 0
{ 
public 

class 
UserDeleteHandler "
:# $
IRequestHandler% 4
<4 5
UserDeleteRequest5 F
,F G
UserDeleteResponseH Z
>Z [
{ 
private 
readonly 
ILogger  
<  !
UserDeleteHandler! 2
>2 3
logger4 :
;: ;
private 
readonly 
IUserRepository (
userRepository) 7
;7 8
private 
readonly 
IMapper  
mapper! '
;' (
public 
UserDeleteHandler  
(  !
ILogger 
< 
UserDeleteHandler %
>% &
logger' -
,- .
IUserRepository 
userRepository *
,* +
IMapper 
mapper 
) 
{ 	
this 
. 
logger 
= 
logger  
;  !
this 
. 
userRepository 
=  !
userRepository" 0
;0 1
this 
. 
mapper 
= 
mapper  
;  !
} 	
public   
async   
Task   
<   
UserDeleteResponse   ,
>  , -
Handle  . 4
(  4 5
UserDeleteRequest  5 F
request  G N
,  N O
CancellationToken  P a
cancellationToken  b s
)  s t
{!! 	
var"" 
userCurrent"" 
="" 
await"" #
userRepository""$ 2
.""2 3
GetByIdAsync""3 ?
(""? @
Convert""@ G
.""G H
ToInt32""H O
(""O P
request""P W
.""W X

TokenModel""X b
.""b c
Id""c e
)""e f
)""f g
;""g h
if## 
(## 
userCurrent## 
==## 
null## #
)### $
{$$ 
logger%% 
.%% 

LogWarning%% !
(%%! "
$"%%" $1
%No se encuentra usuario Token con ID:%%$ I
{%%I J
request%%J Q
.%%Q R

TokenModel%%R \
.%%\ ]
Id%%] _
}%%_ `
"%%` a
)%%a b
;%%b c
throw&& 
new&& 
CustomException&& )
(&&) *
Models&&* 0
.&&0 1
Enums&&1 6
.&&6 7
MessageCodesApi&&7 F
.&&F G
IncorrectData&&G T
,&&T U
Models&&V \
.&&\ ]
Enums&&] b
.&&b c
ResponseType&&c o
.&&o p
Error&&p u
,&&u v
System&&w }
.&&} ~
Net	&&~ Å
.
&&Å Ç
HttpStatusCode
&&Ç ê
.
&&ê ë
Unauthorized
&&ë ù
)
&&ù û
;
&&û ü
}'' 
var)) 
userToDesactive)) 
=))  !
await))" '
userRepository))( 6
.))6 7
GetByIdAsync))7 C
())C D
Convert))D K
.))K L
ToInt32))L S
())S T
request))T [
.))[ \
Id))\ ^
)))^ _
)))_ `
;))` a
if** 
(** 
userToDesactive** 
==**  "
null**# '
)**' (
{++ 
throw-- 
new-- 
CustomException-- )
(--) *
Models--* 0
.--0 1
Enums--1 6
.--6 7
MessageCodesApi--7 F
.--F G
IncorrectData--G T
,--T U
Models--V \
.--\ ]
Enums--] b
.--b c
ResponseType--c o
.--o p
Error--p u
,--u v
System--w }
.--} ~
Net	--~ Å
.
--Å Ç
HttpStatusCode
--Ç ê
.
--ê ë
Unauthorized
--ë ù
)
--ù û
;
--û ü
}.. 
if// 
(// 
!// 
userToDesactive//  
.//  !
IsActive//! )
)//) *
{00 
logger11 
.11 

LogWarning11 !
(11! "
$"11" $
El usuario con Id: 11$ 7
{117 8
request118 ?
.11? @
Id11@ B
}11B C!
 ya est√° desactivado11C W
"11W X
)11X Y
;11Y Z
throw22 
new22 
CustomException22 )
(22) *
Models22* 0
.220 1
Enums221 6
.226 7
MessageCodesApi227 F
.22F G
UserIsInactive22G U
,22U V
Models22W ]
.22] ^
Enums22^ c
.22c d
ResponseType22d p
.22p q
Error22q v
,22v w
System22x ~
.22~ 
Net	22 Ç
.
22Ç É
HttpStatusCode
22É ë
.
22ë í
Unauthorized
22í û
)
22û ü
;
22ü †
}33 
userToDesactive44 
.44 
IsActive44 $
=44% &
false44' ,
;44, -
var55 
isUpdate55 
=55 
await55  
userRepository55! /
.55/ 0
Update550 6
(556 7
userToDesactive557 F
)55F G
;55G H
if66 
(66 
!66 
isUpdate66 
)66 
{77 
logger88 
.88 

LogWarning88 !
(88! "
$"88" $)
No se pudo actualizar Usuario88$ A
"88A B
)88B C
;88C D
throw99 
new99 
CustomException99 )
(99) *
Models99* 0
.990 1
Enums991 6
.996 7
MessageCodesApi997 F
.99F G
NotUpdateRecord99G V
,99V W
Models99X ^
.99^ _
Enums99_ d
.99d e
ResponseType99e q
.99q r
Error99r w
,99w x
System99y 
.	99 Ä
Net
99Ä É
.
99É Ñ
HttpStatusCode
99Ñ í
.
99í ì
Unauthorized
99ì ü
)
99ü †
;
99† °
}:: 
return;; 
mapper;; 
.;; 
Map;; 
<;; 
UserDeleteResponse;; 0
>;;0 1
(;;1 2
userToDesactive;;2 A
);;A B
;;;B C
}<< 	
}>> 
}?? ±)
cC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\User\UserGetHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
User, 0
{ 
public 

class 
UserGetHandler 
:  !
IRequestHandler" 1
<1 2
UserGetRequest2 @
,@ A
UserGetResponseB Q
>Q R
{ 
private 
readonly 
IUserRepository (
userRepository) 7
;7 8
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
ValidateIntegrity *
validateIntegrity+ <
;< =
public 
UserGetHandler 
( 
IUserRepository 
userRepository *
,* +
IMapper 
mapper 
, 
ValidateIntegrity 
validateIntegrity /
) 
{ 	
this 
. 
userRepository 
=  !
userRepository" 0
;0 1
this 
. 
mapper 
= 
mapper  
;  !
this   
.   
validateIntegrity   "
=  # $
validateIntegrity  % 6
;  6 7
}!! 	
public## 
async## 
Task## 
<## 
UserGetResponse## )
>##) *
Handle##+ 1
(##1 2
UserGetRequest##2 @
request##A H
,##H I
CancellationToken##J [
cancellationToken##\ m
)##m n
{$$ 	
await%% 
validateIntegrity%% #
.%%# $
ValidateUser%%$ 0
(%%0 1
request%%1 8
)%%8 9
;%%9 :
List&& 
<&& 
Models&& 
.&& 

Persitence&& "
.&&" #
User&&# '
>&&' (
listUser&&) 1
;&&1 2
if'' 
('' 
request'' 
.'' 
Id'' 
!='' 
null'' "
)''" #
listUser(( 
=(( 
((( 
await(( !
userRepository((" 0
.((0 1
GetAsync((1 9
(((9 :
u((: ;
=>((< >
u((? @
.((@ A
Id((A C
==((D F
request((G N
.((N O
Id((O Q
)((Q R
)((R S
.((S T
ToList((T Z
(((Z [
)(([ \
;((\ ]
else)) 
listUser** 
=** 
(** 
await** !
userRepository**" 0
.**0 1
GetAsync**1 9
(**9 :
)**: ;
)**; <
.**< =
ToList**= C
(**C D
)**D E
;**E F
if++ 
(++ 
request++ 
.++ 
	FirstName++ !
!=++" $
null++% )
)++) *
listUser,, 
=,, 
(,, 
await,, !
userRepository,," 0
.,,0 1
GetAsync,,1 9
(,,9 :
u,,: ;
=>,,< >
u,,? @
.,,@ A
	FirstName,,A J
==,,K M
request,,N U
.,,U V
	FirstName,,V _
),,_ `
),,` a
.,,a b
ToList,,b h
(,,h i
),,i j
;,,j k
if-- 
(-- 
request-- 
.-- 
LastName--  
!=--! #
null--$ (
)--( )
listUser.. 
=.. 
(.. 
await.. !
userRepository.." 0
...0 1
GetAsync..1 9
(..9 :
u..: ;
=>..< >
u..? @
...@ A
FirstLastName..A N
==..O Q
request..R Y
...Y Z
LastName..Z b
)..b c
)..c d
...d e
ToList..e k
(..k l
)..l m
;..m n
if// 
(// 
request// 
.// 
Username//  
!=//! #
null//$ (
)//( )
listUser00 
=00 
(00 
await00 !
userRepository00" 0
.000 1
GetAsync001 9
(009 :
u00: ;
=>00< >
u00? @
.00@ A
UserName00A I
==00J L
request00M T
.00T U
Username00U ]
)00] ^
)00^ _
.00_ `
ToList00` f
(00f g
)00g h
;00h i
var11 
listUserGet11 
=11 
mapper11 $
.11$ %
Map11% (
<11( )
List11) -
<11- .
Models11. 4
.114 5

Persitence115 ?
.11? @
User11@ D
>11D E
,11E F
List11G K
<11K L
UserResponseBase11L \
>11\ ]
>11] ^
(11^ _
listUser11_ g
)11g h
;11h i
return22 
new22 
UserGetResponse22 &
(22& '
)22' (
{33 
ListUser44 
=44 
listUserGet44 &
}55 
;55 
}66 	
}77 
}88 ã$
fC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\User\UserUpdateHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
User, 0
{ 
public 

class 
UserUpdateHandler "
:# $
IRequestHandler% 4
<4 5
UserUpdateRequest5 F
,F G
UserUpdateResponseH Z
>Z [
{ 
private 
readonly 
IUserRepository (
userRepository) 7
;7 8
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
ValidateIntegrity *
validateIntegrity+ <
;< =
public 
UserUpdateHandler  
(  !
IUserRepository 
userRepository *
,* +
IMapper 
mapper 
, 
ValidateIntegrity 
validateIntegrity /
) 
{ 	
this 
. 
userRepository 
=  !
userRepository" 0
;0 1
this 
. 
mapper 
= 
mapper  
;  !
this 
. 
validateIntegrity "
=# $
validateIntegrity% 6
;6 7
} 	
public!! 
async!! 
Task!! 
<!! 
UserUpdateResponse!! ,
>!!, -
Handle!!. 4
(!!4 5
UserUpdateRequest!!5 F
request!!G N
,!!N O
CancellationToken!!P a
cancellationToken!!b s
)!!s t
{"" 	
var$$ 
userCurrent$$ 
=$$ 
await$$ $
validateIntegrity$$% 6
.$$6 7
ValidateUser$$7 C
($$C D
request$$D K
)$$K L
;$$L M
var&& 

userUpdate&& 
=&& 
mapper&& #
.&&# $
Map&&$ '
<&&' (
Models&&( .
.&&. /

Persitence&&/ 9
.&&9 :
User&&: >
>&&> ?
(&&? @
request&&@ G
)&&G H
;&&H I
userCurrent'' 
.'' 
DNI'' 
='' 

userUpdate'' (
.''( )
DNI'') ,
;'', -
userCurrent(( 
.(( 
	FirstName(( !
=((" #

userUpdate(($ .
.((. /
	FirstName((/ 8
;((8 9
userCurrent)) 
.)) 
SecondLastName)) &
=))' (

userUpdate))) 3
.))3 4
SecondLastName))4 B
;))B C
userCurrent** 
.** 
FirstLastName** %
=**& '

userUpdate**( 2
.**2 3
FirstLastName**3 @
;**@ A
userCurrent++ 
.++ 

SecondName++ "
=++# $

userUpdate++% /
.++/ 0

SecondName++0 :
;++: ;
userCurrent,, 
.,, 
UserName,,  
=,,! "

userUpdate,,# -
.,,- .
UserName,,. 6
;,,6 7
userCurrent-- 
.-- 
	BirthDate-- !
=--" #

userUpdate--$ .
.--. /
	BirthDate--/ 8
;--8 9
var// 
isUserUpdate// 
=// 
await// $
userRepository//% 3
.//3 4
Update//4 :
(//: ;
userCurrent//; F
)//F G
;//G H
if00 
(00 
!00 
isUserUpdate00 
)00 
throw11 
new11 
CustomException11 )
(11) *
Models11* 0
.110 1
Enums111 6
.116 7
MessageCodesApi117 F
.11F G
NotUpdateRecord11G V
,11V W
Models11X ^
.11^ _
Enums11_ d
.11d e
ResponseType11e q
.11q r
Error11r w
,11w x
System11y 
.	11 Ä
Net
11Ä É
.
11É Ñ
HttpStatusCode
11Ñ í
.
11í ì!
InternalServerError
11ì ¶
)
11¶ ß
;
11ß ®
var22 
userResponse22 
=22 
mapper22 %
.22% &
Map22& )
<22) *
UserUpdateResponse22* <
>22< =
(22= >
userCurrent22> I
)22I J
;22J K
return33 
userResponse33 
;33  
}44 	
}66 
}77 Ã7
fC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Vote\VoteCreateHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
Vote, 0
{ 
public 

class 
VoteCreateHandler "
:# $
IRequestHandler% 4
<4 5
VoteCreateRequest5 F
,F G
VoteCreateResponseH Z
>Z [
{ 
private 
readonly 
IVoteRepository (
_voteRepository) 8
;8 9
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
ValidateIntegrity *
validateIntegrity+ <
;< =
public 
VoteCreateHandler  
(  !
IVoteRepository 
voteRepository &
,& '
IMapper 
mapper 
, 
ValidateIntegrity 
validateIntegrity +
) 	
{ 	
this 
. 
_voteRepository  
=! "
voteRepository# 1
;1 2
this 
. 
_mapper 
= 
mapper !
;! "
this   
.   
validateIntegrity   "
=  # $
validateIntegrity  % 6
;  6 7
}!! 	
public$$ 
async$$ 
Task$$ 
<$$ 
VoteCreateResponse$$ ,
>$$, -
Handle$$. 4
($$4 5
VoteCreateRequest$$5 F
request$$G N
,$$N O
CancellationToken$$P a
cancellationToken$$b s
)$$s t
{%% 	
await'' 
validateIntegrity'' #
.''# $
ValidateUser''$ 0
(''0 1
request''1 8
.''8 9
IdUser''9 ?
)''? @
;''@ A
var)) 
eventCurrent)) 
=)) 
await)) $
validateIntegrity))% 6
.))6 7
ValidateEvent))7 D
())D E
request))E L
.))L M
IdEvent))M T
)))T U
;))U V
var++ 
participants++ 
=++ 
await++ $
_voteRepository++% 4
.++4 5
GetAsync++5 =
(++= >
v++> ?
=>++@ B
v++C D
.++D E
IdEvent++E L
==++M O
request++P W
.++W X
IdEvent++X _
)++_ `
;++` a
var-- 
hasRegister-- 
=-- 
participants-- *
.--* +
Any--+ .
(--. /
u--/ 0
=>--1 3
u--4 5
.--5 6
IdUser--6 <
==--= ?
request--@ G
.--G H
IdUser--H N
)--N O
;--O P
if.. 
(.. 
!.. 
hasRegister.. 
).. 
throw// 
new// 
CustomException// )
(//) *
Models//* 0
.//0 1
Enums//1 6
.//6 7
MessageCodesApi//7 F
.//F G
UserRegisterEvent//G X
,//X Y
Models//Z `
.//` a
Enums//a f
.//f g
ResponseType//g s
.//s t
Error//t y
,//y z
System	//{ Å
.
//Å Ç
Net
//Ç Ö
.
//Ö Ü
HttpStatusCode
//Ü î
.
//î ï

BadRequest
//ï ü
)
//ü †
;
//† °
if11 
(11 
eventCurrent11 
.11 
	MaxPeople11 &
&&11' )
participants11* 6
.116 7
Count117 <
(11< =
)11= >
>11? @
eventCurrent11A M
.11M N
NumberMaxPeople11N ]
)11] ^
throw22 
new22 
CustomException22 )
(22) *
Models22* 0
.220 1
Enums221 6
.226 7
MessageCodesApi227 F
.22F G 
LimitMaxParticipants22G [
,22[ \
Models22] c
.22c d
Enums22d i
.22i j
ResponseType22j v
.22v w
Error22w |
,22| }
System	22~ Ñ
.
22Ñ Ö
Net
22Ö à
.
22à â
HttpStatusCode
22â ó
.
22ó ò
Conflict
22ò †
)
22† °
;
22° ¢
if44 
(44 
!44 
eventCurrent44 
.44 "
ListEventAdministrator44 4
.444 5
Any445 8
(448 9
e449 :
=>44; =
e44> ?
.44? @
IdUser44@ F
==44G I
request44J Q
.44Q R
UserContext44R ]
.44] ^
Id44^ `
)44` a
)44a b
throw55 
new55 
CustomException55 )
(55) *
Models55* 0
.550 1
Enums551 6
.556 7
MessageCodesApi557 F
.55F G'
UserIsnotAdministratorEvent55G b
,55b c
Models55d j
.55j k
Enums55k p
.55p q
ResponseType55q }
.55} ~
Error	55~ É
,
55É Ñ
System
55Ö ã
.
55ã å
Net
55å è
.
55è ê
HttpStatusCode
55ê û
.
55û ü

BadRequest
55ü ©
)
55© ™
;
55™ ´
var88 
newVote88 
=88 
new88 
Models88 $
.88$ %

Persitence88% /
.88/ 0
Vote880 4
(884 5
)885 6
{99 
IdEvent:: 
=:: 
request:: !
.::! "
IdEvent::" )
,::) *
IdUser;; 
=;; 
request;;  
.;;  !
IdUser;;! '
,;;' (
IsActive<< 
=<< 
true<< 
,<<  
DateInscription== 
===  !
DateTime==" *
.==* +
Now==+ .
}>> 
;>> 
var?? 
isCreate?? 
=?? 
await??  
_voteRepository??! 0
.??0 1
CreateAsync??1 <
(??< =
newVote??= D
)??D E
;??E F
if@@ 
(@@ 
!@@ 
isCreate@@ 
)@@ 
throwAA 
newAA 
CustomExceptionAA )
(AA) *
ModelsAA* 0
.AA0 1
EnumsAA1 6
.AA6 7
MessageCodesApiAA7 F
.AAF G
NotCreateRecordAAG V
,AAV W
ModelsAAX ^
.AA^ _
EnumsAA_ d
.AAd e
ResponseTypeAAe q
.AAq r
ErrorAAr w
,AAw x
SystemAAy 
.	AA Ä
Net
AAÄ É
.
AAÉ Ñ
HttpStatusCode
AAÑ í
.
AAí ì!
InternalServerError
AAì ¶
)
AA¶ ß
;
AAß ®
returnBB 
_mapperBB 
.BB 
MapBB 
<BB 
VoteCreateResponseBB 1
>BB1 2
(BB2 3
newVoteBB3 :
)BB: ;
;BB; <
}CC 	
}EE 
}FF ’#
fC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Vote\VoteDeleteHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
Vote, 0
{ 
public 

class 
VoteDeleteHandler "
:# $
IRequestHandler% 4
<4 5
VoteDeleteRequest5 F
,F G
VoteDeleteResponseH Z
>Z [
{ 
private 
readonly 
IVoteRepository (
_VoteRepository) 8
;8 9
private 
readonly 
IMapper  
_mapper! (
;( )
private	 
readonly 
ValidateIntegrity +
validateIntegrity, =
;= >
public 
VoteDeleteHandler  
(  !
IVoteRepository 
VoteRepository *
,* +
IMapper 
mapper 
, 
ValidateIntegrity 
validateIntegrity /
)/ 0
{ 	
this 
. 
_VoteRepository  
=! "
VoteRepository# 1
;1 2
this 
. 
_mapper 
= 
mapper !
;! "
this 
. 
validateIntegrity "
=# $
validateIntegrity% 6
;6 7
} 	
public   
async   
Task   
<   
VoteDeleteResponse   ,
>  , -
Handle  . 4
(  4 5
VoteDeleteRequest  5 F
request  G N
,  N O
CancellationToken  P a
cancellationToken  b s
)  s t
{!! 	
var## 
eventCurrent## 
=## 
await## $
validateIntegrity##% 6
.##6 7
ValidateEvent##7 D
(##D E
request##E L
.##L M
IdEvent##M T
)##T U
;##U V
var%% 
voteCurrent%% 
=%% 
(%% 
await%% $
_VoteRepository%%% 4
.%%4 5
GetAsyncInclude%%5 D
(%%D E
v%%E F
=>%%F H
v%%I J
.%%J K
IdEvent%%K R
==%%S U
eventCurrent%%V b
.%%b c
Id%%c e
&&%%f h
v&&D E
.&&E F
IdUser&&F L
==&&M O
request&&P W
.&&W X
UserContext&&X c
.&&c d
Id&&d f
)&&f g
)&&g h
.&&h i
FirstOrDefault&&i w
(&&w x
)&&x y
;&&y z
if'' 
('' 
voteCurrent'' 
=='' 
null'' #
)''# $
throw(( 
new(( 
CustomException(( )
((() *
Models((* 0
.((0 1
Enums((1 6
.((6 7
MessageCodesApi((7 F
.((F G
NotFindRecord((G T
,((T U
Models((V \
.((\ ]
Enums((] b
.((b c
ResponseType((c o
.((o p
Error((p u
,((u v
System((w }
.((} ~
Net	((~ Å
.
((Å Ç
HttpStatusCode
((Ç ê
.
((ê ë
Conflict
((ë ô
)
((ô ö
;
((ö õ
voteCurrent** 
.** 
IsActive**  
=**  !
false**! &
;**& '
var++ 
isUpdate++ 
=++ 
await++  
_VoteRepository++! 0
.++0 1
Update++1 7
(++7 8
voteCurrent++8 C
)++C D
;++D E
if,, 
(,, 
!,, 
isUpdate,, 
),, 
throw-- 
new-- 
CustomException-- )
(--) *
Models--* 0
.--0 1
Enums--1 6
.--6 7
MessageCodesApi--7 F
.--F G
NotDeleteRecord--G V
,--V W
Models--X ^
.--^ _
Enums--_ d
.--d e
ResponseType--e q
.--q r
Error--r w
,--w x
System--y 
.	-- Ä
Net
--Ä É
.
--É Ñ
HttpStatusCode
--Ñ í
.
--í ì!
InternalServerError
--ì ¶
)
--¶ ß
;
--ß ®
return.. 
_mapper.. 
... 
Map.. 
<.. 
VoteDeleteResponse.. 1
>..1 2
(..2 3
voteCurrent..3 >
)..> ?
;..? @
}// 	
}22 
}33 ˇ
cC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Vote\VoteGetHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
Vote, 0
{ 
public 

class 
VoteGetHandler 
:  !
IRequestHandler" 1
<1 2
VoteGetRequest2 @
,@ A
VoteGetResponseB Q
>Q R
{ 
private 
readonly 
IVoteRepository (
_VoteRepository) 8
;8 9
private 
readonly 
IMapper  
_mapper! (
;( )
public 
VoteGetHandler 
( 
IVoteRepository 
VoteRepository *
,* +
IMapper 
mapper 
) 
{ 	
this 
. 
_VoteRepository  
=! "
VoteRepository# 1
;1 2
this 
. 
_mapper 
= 
mapper !
;! "
} 	
public 
async 
Task 
< 
VoteGetResponse )
>) *
Handle+ 1
(1 2
VoteGetRequest2 @
requestA H
,H I
CancellationTokenJ [
cancellationToken\ m
)m n
{ 	
var 
votes 
= 
( 
await 
_VoteRepository .
.. /
GetAsync/ 7
(7 8
)8 9
)9 :
.: ;
ToList; A
(A B
)B C
;C D
return   
new   
VoteGetResponse   &
(  & '
)  ' (
{!! 
	ListVotes"" 
="" 
_mapper"" $
.""$ %
Map""% (
<""( )
List"") -
<""- .
VoteResponseBase"". >
>""> ?
>""? @
(""@ A
votes""A F
)""F G
}## 
;## 
}$$ 	
}'' 
}(( Á(
fC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\Vote\VoteUpdateHandler.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
BusinessLogic +
.+ ,
Vote, 0
{ 
public 

class 
VoteUpdateHandler "
:# $
IRequestHandler% 4
<4 5
VoteUpdateRequest5 F
,F G
VoteUpdateResponseH Z
>Z [
{ 
private 
readonly 
IVoteRepository (
_VoteRepository) 8
;8 9
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly  
ValidateIntegrity! 2
validateIntegrity3 D
;D E
public 
VoteUpdateHandler  
(  !
IVoteRepository 
VoteRepository *
,* +
IMapper 
mapper 
, 
ValidateIntegrity 
validateIntegrity /
)/ 0
{ 	
this 
. 
_VoteRepository  
=! "
VoteRepository# 1
;1 2
this 
. 
_mapper 
= 
mapper !
;! "
this 
. 
validateIntegrity "
=# $
validateIntegrity% 6
;6 7
} 	
public## 
async## 
Task## 
<## 
VoteUpdateResponse## ,
>##, -
Handle##. 4
(##4 5
VoteUpdateRequest##5 F
request##G N
,##N O
CancellationToken##P a
cancellationToken##b s
)##s t
{$$ 	
var&& 
eventCurrent&& 
=&& 
await&& $
validateIntegrity&&% 6
.&&6 7
ValidateEvent&&7 D
(&&D E
request&&E L
.&&L M
IdEvent&&M T
)&&T U
;&&U V
var(( 
candidateCurrent((  
=((! "
await((# (
validateIntegrity(() :
.((: ;
ValidateCandiate((; K
(((K L
request((L S
.((S T
IdCandidate((T _
)((_ `
;((` a
if)) 
()) 
candidateCurrent))  
.))  !
IdEvent))! (
!=))) +
eventCurrent)), 8
.))8 9
Id))9 ;
))); <
throw** 
new** 
CustomException** )
(**) *
Models*** 0
.**0 1
Enums**1 6
.**6 7
MessageCodesApi**7 F
.**F G
DataInconsistency**G X
,**X Y
Models**Z `
.**` a
Enums**a f
.**f g
ResponseType**g s
.**s t
Error**t y
,**y z
System	**{ Å
.
**Å Ç
Net
**Ç Ö
.
**Ö Ü
HttpStatusCode
**Ü î
.
**î ï
Conflict
**ï ù
)
**ù û
;
**û ü
var,, 
voteCurrent,, 
=,, 
(,, 
await,, $
_VoteRepository,,% 4
.,,4 5
GetAsyncInclude,,5 D
(,,D E
v,,E F
=>,,G I
v,,J K
.,,K L
IdEvent,,L S
==,,T V
eventCurrent,,W c
.,,c d
Id,,d f
&&,,g i
v--M N
.--N O
IdUser--O U
==--V X
request--Y `
.--` a
UserContext--a l
.--l m
Id--m o
)--o p
)--p q
.--q r
FirstOrDefault	--r Ä
(
--Ä Å
)
--Å Ç
;
--Ç É
voteCurrent// 
.// 
IdCandidate// #
=//$ %
candidateCurrent//& 6
.//6 7
Id//7 9
;//9 :
voteCurrent00 
.00 
DateVote00  
=00! "
DateTime00# +
.00+ ,
Now00, /
;00/ 0
voteCurrent11 
.11 
HasVote11 
=11  !
true11" &
;11& '
var33 
isUpdate33 
=33 
await33  
_VoteRepository33! 0
.330 1
Update331 7
(337 8
voteCurrent338 C
)33C D
;33D E
if44 
(44 
!44 
isUpdate44 
)44 
throw55 
new55 
CustomException55 )
(55) *
Models55* 0
.550 1
Enums551 6
.556 7
MessageCodesApi557 F
.55F G
NotUpdateRecord55G V
,55V W
Models55X ^
.55^ _
Enums55_ d
.55d e
ResponseType55e q
.55q r
Error55r w
,55w x
System55y 
.	55 Ä
Net
55Ä É
.
55É Ñ
HttpStatusCode
55Ñ í
.
55í ì!
InternalServerError
55ì ¶
)
55¶ ß
;
55ß ®
return66 
_mapper66 
.66 
Map66 
<66 
VoteUpdateResponse66 1
>661 2
(662 3
voteCurrent663 >
)66> ?
;66? @
}77 	
};; 
}<< ä
åC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\obj\Debug\net5.0\.NETCoreApp,Version=v5.0.AssemblyAttributes.cs
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
]| }Œ
èC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.BusinessLogic\obj\Debug\net5.0\Dach.ElectionSystem.BusinessLogic.AssemblyInfo.cs
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
$str6 Y
)Y Z
]Z [
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
$str6 Y
)Y Z
]Z [
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
$str4 W
)W X
]X Y
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