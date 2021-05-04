íS
aC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Services\Data\ValidateIntegrity.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Services &
.& '
Data' +
{ 
public 

class 
ValidateIntegrity "
{ 
private 
readonly 
IUserRepository (
userRepository) 7
;7 8
private 
readonly 
IVoteRepository (
voteRepository) 7
;7 8
private 
readonly 
IEventRepository )
eventRepository* 9
;9 :
private 
readonly  
ICandidateRepository -
candidateRepository. A
;A B
public 
ValidateIntegrity  
(  !
IUserRepository 
userRepository *
,* +
IVoteRepository 
voteRepository *
,* +
IEventRepository 
eventRepository ,
,, - 
ICandidateRepository  
candidateRepository! 4
)4 5
{ 	
this 
. 
userRepository 
=  !
userRepository" 0
;0 1
this 
. 
voteRepository 
=  !
voteRepository" 0
;0 1
this 
. 
eventRepository  
=! "
eventRepository# 2
;2 3
this 
. 
candidateRepository $
=% &
candidateRepository' :
;: ;
} 	
public++ 
async++ 
Task++ 
<++ 
Event++ 
>++  
ValidateEvent++! .
(++. /
int++/ 2
id++3 5
)++5 6
{,, 	
var-- 

existEvent-- 
=-- 
await-- "
eventRepository--# 2
.--2 3
GetAsync--3 ;
(--; <
u--< =
=>--> @
u--A B
.--B C
Id--C E
==--F H
id--I K
,--K L
includeProperties--M ^
:--^ _
$"--_ a
{--a b
nameof--b h
(--h i
Event--i n
.--n o
ListCandidate--o |
)--| }
}--} ~
"--~ 
)	-- Ä
;
--Ä Å
if.. 
(.. 

existEvent.. 
... 
Count..  
(..  !
)..! "
!=..# %
$num..& '
)..' (
throw// 
new// 
CustomException// )
(//) *
MessageCodesApi//* 9
.//9 :
NotFindRecord//: G
,//G H
ResponseType//I U
.//U V
Error//V [
,//[ \
HttpStatusCode//] k
.//k l
NotFound//l t
,//t u
$"//v x-
 No se encuntra el evento con Id:	//x ò
{
//ò ô
id
//ô õ
}
//õ ú
"
//ú ù
)
//ù û
;
//û ü
var00 
eventCurrent00 
=00 

existEvent00 )
.00) *
First00* /
(00/ 0
)000 1
;001 2
if11 
(11 
eventCurrent11 
.11 
IsDelete11 %
)11% &
throw22 
new22 
CustomException22 )
(22) *
MessageCodesApi22* 9
.229 :
NotFindRecord22: G
,22G H
ResponseType22I U
.22U V
Error22V [
,22[ \
HttpStatusCode22] k
.22k l
NotFound22l t
,22t u
$"22v x
El evento con Id:	22x â
{
22â ä
id
22ä å
}
22å ç
 ha sido borrado
22ç ù
"
22ù û
)
22û ü
;
22ü †
return33 

existEvent33 
.33 
FirstOrDefault33 ,
(33, -
)33- .
;33. /
}44 	
public66 
async66 
Task66 
<66 
User66 
>66 
ValidateUser66  ,
(66, -
int66- 0
idUser661 7
)667 8
{77 	
var88 
	existUser88 
=88 
await88 !
userRepository88" 0
.880 1
GetAsync881 9
(889 :
u88: ;
=>88< >
u88? @
.88@ A
Id88A C
==88D F
idUser88G M
)88M N
;88N O
if99 
(99 
	existUser99 
.99 
Count99 
(99  
)99  !
!=99" $
$num99% &
)99& '
throw:: 
new:: 
CustomException:: )
(::) *
MessageCodesApi::* 9
.::9 :
NotFindRecord::: G
,::G H
ResponseType::I U
.::U V
Error::V [
,::[ \
HttpStatusCode::] k
.::k l
Unauthorized::l x
,::x y
$"::z |.
!No se encuntra el Usuario con Id:	::| ù
{
::ù û
idUser
::û §
}
::§ •
"
::• ¶
)
::¶ ß
;
::ß ®
return;; 
	existUser;; 
.;; 
FirstOrDefault;; +
(;;+ ,
);;, -
;;;- .
}<< 	
public>> 
async>> 
Task>> 
<>> 
User>> 
>>> 
ValidateUser>>  ,
(>>, -
IRequestBase>>- 9
request>>: A
)>>A B
{?? 	
var@@ 
	existUser@@ 
=@@ 
await@@ !
userRepository@@" 0
.@@0 1
GetAsync@@1 9
(@@9 :
u@@: ;
=>@@< >
u@@? @
.@@@ A
Id@@A C
==@@D F
System@@G M
.@@M N
Convert@@N U
.@@U V
ToInt32@@V ]
(@@] ^
request@@^ e
.@@e f

TokenModel@@f p
.@@p q
Id@@q s
)@@s t
&&@@u w
uAA@ A
.AAA B
UserNameAAB J
==AAK M
requestAAN U
.AAU V

TokenModelAAV `
.AA` a
UsernameAAa i
&&AAj l
uBB@ A
.BBA B
EmailBBB G
==BBH J
requestBBK R
.BBR S

TokenModelBBS ]
.BB] ^
EmailBB^ c
,BBc d
includePropertiesCC@ Q
:CCQ R
$"CCS U
{CCU V
nameofCCV \
(CC\ ]
UserCC] a
.CCa b"
ListEventAdministratorCCb x
)CCx y
}CCy z
,CCz {
{CC{ |
nameof	CC| Ç
(
CCÇ É
User
CCÉ á
.
CCá à
EventNumber
CCà ì
)
CCì î
}
CCî ï
"
CCï ñ
)
CCñ ó
;
CCó ò
ifDD 
(DD 
	existUserDD 
.DD 
CountDD 
(DD  
)DD  !
!=DD" $
$numDD% &
)DD& '
throwEE 
newEE 
CustomExceptionEE )
(EE) *
MessageCodesApiEE* 9
.EE9 :
DataInconsistencyEE: K
,EEK L
ResponseTypeEEM Y
.EEY Z
ErrorEEZ _
,EE_ `
HttpStatusCodeEEa o
.EEo p
UnauthorizedEEp |
,EE| }
$"	EE~ Ä0
"No se encuntra usuario con correo:
EEÄ ¢
{
EE¢ £
request
EE£ ™
.
EE™ ´

TokenModel
EE´ µ
.
EEµ ∂
Email
EE∂ ª
}
EEª º
"
EEº Ω
)
EEΩ æ
;
EEæ ø
returnFF 
	existUserFF 
.FF 
FirstOrDefaultFF +
(FF+ ,
)FF, -
;FF- .
}GG 	
publicII 
asyncII 
TaskII 
<II 
VoteII 
>II 
ValidateVoteII  ,
(II, -
intII- 0
idII1 3
)II3 4
{JJ 	
varKK 
	existVoteKK 
=KK 
awaitKK !
voteRepositoryKK" 0
.KK0 1
GetAsyncKK1 9
(KK9 :
uKK: ;
=>KK< >
uKK? @
.KK@ A
IdKKA C
==KKD F
idKKG I
)KKI J
;KKJ K
ifLL 
(LL 
	existVoteLL 
.LL 
CountLL 
(LL  
)LL  !
!=LL" $
$numLL% &
)LL& '
throwMM 
newMM 
CustomExceptionMM )
(MM) *
MessageCodesApiMM* 9
.MM9 :
NotFindRecordMM: G
,MMG H
ResponseTypeMMI U
.MMU V
ErrorMMV [
,MM[ \
HttpStatusCodeMM] k
.MMk l
NotFoundMMl t
,MMt u
$"MMv x+
No se encuntra el voto con Id:	MMx ñ
{
MMñ ó
id
MMó ô
}
MMô ö
"
MMö õ
)
MMõ ú
;
MMú ù
returnNN 
	existVoteNN 
.NN 
FirstOrDefaultNN +
(NN+ ,
)NN, -
;NN- .
}OO 	
publicQQ 
asyncQQ 
TaskQQ 
<QQ 
	CandidateQQ #
>QQ# $
ValidateCandiateQQ% 5
(QQ5 6
intQQ6 9
idQQ: <
)QQ< =
{RR 	
varSS 
existCandidateSS 
=SS  
awaitSS! &
candidateRepositorySS' :
.SS: ;
GetAsyncIncludeSS; J
(SSJ K
uSSK L
=>SSM O
uSSP Q
.SSQ R
IdSSR T
==SSU W
idSSX Z
,TTL M
includePropertiesTTN _
:TT_ `
uTTa b
=>TTc e
$"TTf h
{TTh i
nameofTTi o
(TTo p
uTTp q
.TTq r
UserTTr v
)TTv w
}TTw x
"TTx y
)TTy z
;TTz {
ifUU 
(UU 
existCandidateUU 
.UU 
CountUU $
(UU$ %
)UU% &
!=UU' )
$numUU* +
)UU+ ,
throwVV 
newVV 
CustomExceptionVV )
(VV) *
MessageCodesApiVV* 9
.VV9 :
NotFindRecordVV: G
,VVG H
ResponseTypeVVI U
.VVU V
ErrorVVV [
,VV[ \
HttpStatusCodeVV] k
.VVk l
NotFoundVVl t
,VVt u
$"VVv x0
#No se encuntra el candidato con Id:	VVx õ
{
VVõ ú
id
VVú û
}
VVû ü
"
VVü †
)
VV† °
;
VV° ¢
returnWW 
existCandidateWW !
.WW! "
FirstOrDefaultWW" 0
(WW0 1
)WW1 2
;WW2 3
}XX 	
}ZZ 
}[[ È	
fC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Services\Intrastructure\InitServices.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Services &
.& '
Intrastructure' 5
{ 
public 

static 
class 
InitServices $
{		 
public

	 
static

 
void

 
AddServices

 '
(

' (
this

( ,
IServiceCollection

- ?
services

@ H
)

H I
{

J K
services 
. 
AddTransient %
<% &
ITokenService& 3
,3 4
TokenService5 A
>A B
(B C
)C D
;D E
services 
. 
AddTransient %
<% &
ValidateIntegrity& 7
,7 8
ValidateIntegrity9 J
>J K
(K L
)L M
;M N
services 
. 
AddTransient %
<% &
INotification& 3
,3 4 
NotificationSendGrid5 I
>I J
(J K
)K L
;L M
}	 

} 
} Ñ
eC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Services\Notification\INotification.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Services &
.& '
Notification' 3
{ 
public 

	interface 
INotification "
{ 
bool 
SendMail 
( 
	MailModel 
model  %
)% &
;& '
} 
}		 ‹
lC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Services\Notification\NotificationSendGrid.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Services &
.& '
Notification' 3
{ 
public 

class  
NotificationSendGrid %
:& '
INotification( 5
{		 
public

 
bool

 
SendMail

 
(

 
	MailModel

 &
model

' ,
)

, -
{ 	
var 
sendGridClient 
=  
new! $
SendGridClient% 3
(3 4
$str4 {
){ |
;| }
var 
sendGridMessage 
=  !
new" %
SendGridMessage& 5
(5 6
)6 7
;7 8
sendGridMessage 
. 
SetFrom #
(# $
model$ )
.) *
From* .
,. /
$str0 I
)I J
;J K
sendGridMessage 
. 
AddTo !
(! "
model" '
.' (
To( *
)* +
;+ ,
sendGridMessage 
. 
Subject #
=# $
($ %
model% *
.* +
Subject+ 2
)2 3
;3 4
sendGridMessage 
. 
SetTemplateId )
() *
model* /
./ 0
Template0 8
)8 9
;9 :
sendGridMessage 
. 
SetTemplateData +
(+ ,
model, 1
.1 2
Params2 8
)8 9
;9 :
var 
response 
= 
sendGridClient )
.) *
SendEmailAsync* 8
(8 9
sendGridMessage9 H
)H I
.I J
ResultJ P
;P Q
if 
( 
response 
. 

StatusCode #
==$ &
System' -
.- .
Net. 1
.1 2
HttpStatusCode2 @
.@ A
AcceptedA I
)I J
return 
true 
; 
return 
false 
; 
} 	
} 
} ñ
aC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Services\TokenJWT\ITokenService.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Services &
.& '
TokenJWT' /
{ 
public 

	interface 
ITokenService "
{ 
string		 
GenerateTokenJwt		 
(		  
User		  $
user		% )
)		) *
;		* +
void

 
ValidateToken

 
(

 
HttpContext

 &
context

' .
)

. /
;

/ 0

TokenModel 
GetTokenModel  
(  !
HttpContext! ,
context- 4
)4 5
;5 6
} 
} Ín
`C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Services\TokenJWT\TokenService.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Services &
.& '
TokenJWT' /
{ 
public 

class 
TokenService 
: 
ITokenService  -
{ 
private 
readonly 
ILogger  
<  !
TokenService! -
>- .
_logger/ 6
;6 7
private 
readonly 
string 
	secretKey  )
;) *
private 
readonly 
string 

expireTime  *
;* +
public 
TokenService 
( 
IConfiguration *
configuraton+ 7
,7 8
ILogger9 @
<@ A
TokenServiceA M
>M N
loggerO U
)U V
{ 	
_logger 
= 
logger 
; 
	secretKey 
= 
configuraton $
.$ %

GetSection% /
(/ 0
$str0 ;
); <
.< =
Value= B
;B C

expireTime 
= 
configuraton %
.% &
GetValue& .
<. /
string/ 5
>5 6
(6 7
$str7 U
)U V
;V W
} 	
public"" 
string"" 
GenerateTokenJwt"" &
(""& '
User""' +
user"", 0
)""0 1
{## 	
try$$ 
{%% 
var&& 
securityKey&& 
=&&  !
new&&" % 
SymmetricSecurityKey&&& :
(&&: ;
Encoding&&; C
.&&C D
Default&&D K
.&&K L
GetBytes&&L T
(&&T U
	secretKey&&U ^
)&&^ _
)&&_ `
;&&` a
var'' 
signingCredentials'' &
=''' (
new'') ,
SigningCredentials''- ?
(''? @
securityKey''@ K
,''K L
SecurityAlgorithms''M _
.''_ `
HmacSha256Signature''` s
)''s t
;''t u
var** 
claimsIdentity** "
=**# $
new**% (
System**) /
.**/ 0
Collections**0 ;
.**; <
Generic**< C
.**C D
List**D H
<**H I
System**I O
.**O P
Security**P X
.**X Y
Claims**Y _
.**_ `
Claim**` e
>**e f
(**f g
)**g h
{++ 
new,, 
System,, 
.,, 
Security,, '
.,,' (
Claims,,( .
.,,. /
Claim,,/ 4
(,,4 5
Models,,5 ;
.,,; <
Enums,,< A
.,,A B
Claim,,B G
.,,G H
Name,,H L
.,,L M
ToString,,M U
(,,U V
),,V W
,,,W X
user,,Y ]
.,,] ^
UserName,,^ f
??,,f h
String,,h n
.,,n o
Empty,,o t
),,t u
,,,u v
new-- 
System-- 
.-- 
Security-- '
.--' (
Claims--( .
.--. /
Claim--/ 4
(--4 5
Models--5 ;
.--; <
Enums--< A
.--A B
Claim--B G
.--G H
Email--H M
.--M N
ToString--N V
(--V W
)--W X
,--X Y
user--Z ^
.--^ _
Email--_ d
)--d e
,--e f
new.. 
System.. 
... 
Security.. '
...' (
Claims..( .
.... /
Claim../ 4
(..4 5
Models..5 ;
...; <
Enums..< A
...A B
Claim..B G
...G H
Id..H J
...J K
ToString..K S
(..S T
)..T U
,..U V
user..W [
...[ \
Id..\ ^
...^ _
ToString.._ g
(..g h
)..h i
)..i j
,..j k
}// 
;// 
var22 
tokenHandler22  
=22! "
new22# &#
JwtSecurityTokenHandler22' >
(22> ?
)22? @
;22@ A
var33 
jwtSecurityToken33 $
=33% &
tokenHandler33' 3
.333 4"
CreateJwtSecurityToken334 J
(33J K
subject55 
:55 
new55  
ClaimsIdentity55! /
(55/ 0
claimsIdentity550 >
)55> ?
,55? @
	notBefore66 
:66 
DateTime66 '
.66' (
UtcNow66( .
,66. /
expires77 
:77 
DateTime77 %
.77% &
UtcNow77& ,
.77, -

AddMinutes77- 7
(777 8
Convert778 ?
.77? @
ToInt3277@ G
(77G H

expireTime77H R
)77R S
)77S T
,77T U
signingCredentials88 &
:88& '
signingCredentials88( :
)99 
;99 
var;; 
jwtTokenString;; "
=;;# $
tokenHandler;;% 1
.;;1 2

WriteToken;;2 <
(;;< =
jwtSecurityToken;;= M
);;M N
;;;N O
return<< 
jwtTokenString<< %
;<<% &
}== 
catch>> 
(>> 
	Exception>> 
ex>> 
)>>  
{?? 
_logger@@ 
.@@ 
LogError@@  
(@@  !
ex@@! #
.@@# $
Message@@$ +
)@@+ ,
;@@, -
throwAA 
;AA 
}BB 
}CC 	
publicEE 
voidEE 
ValidateTokenEE !
(EE! "
HttpContextEE" -
contextEE. 5
)EE5 6
{FF 	
tryGG 
{HH 
varII 
tokenII 
=II 
contextII #
.II# $
RequestII$ +
.II+ ,
HeadersII, 3
[II3 4
$strII4 C
]IIC D
.IID E
FirstOrDefaultIIE S
(IIS T
)IIT U
?IIU V
.IIV W
SplitIIW \
(II\ ]
$strII] `
)II` a
.IIa b
LastIIb f
(IIf g
)IIg h
;IIh i
ifJJ 
(JJ 
tokenJJ 
==JJ 
nullJJ !
)JJ! "
throwKK 
newKK 
CustomExceptionKK -
(KK- .
MessageCodesApiKK. =
.KK= >
WithOutTokenKK> J
,KKJ K
ResponseTypeKKL X
.KKX Y
ErrorKKY ^
,KK^ _
HttpStatusCodeKK` n
.KKn o
UnauthorizedKKo {
)KK{ |
;KK| }
varLL 
tokenHandlerLL  
=LL! "
newLL# &#
JwtSecurityTokenHandlerLL' >
(LL> ?
)LL? @
;LL@ A
varMM 
keyMM 
=MM 
EncodingMM "
.MM" #
ASCIIMM# (
.MM( )
GetBytesMM) 1
(MM1 2
	secretKeyMM2 ;
)MM; <
;MM< =
tokenHandlerNN 
.NN 
ValidateTokenNN *
(NN* +
tokenNN+ 0
,NN0 1
newNN2 5%
TokenValidationParametersNN6 O
{OO 
ValidateIssuerPP "
=PP# $
falsePP% *
,PP* +
ValidateAudienceQQ $
=QQ% &
falseQQ' ,
,QQ, -
ValidateLifetimeRR $
=RR% &
trueRR' +
,RR+ ,$
ValidateIssuerSigningKeySS ,
=SS- .
trueSS/ 3
,SS3 4
LifetimeValidatorTT %
=TT& '
thisTT( ,
.TT, -
LifetimeValidatorTT- >
,TT> ?
IssuerSigningKeyUU $
=UU% &
newUU' * 
SymmetricSecurityKeyUU+ ?
(UU? @
keyUU@ C
)UUC D
}VV 
,VV 
outVV 
SecurityTokenVV $
validatedTokenVV% 3
)VV3 4
;VV4 5
}YY 
catchZZ 
(ZZ 
ArgumentExceptionZZ $
exZZ% '
)ZZ' (
{\\ 
_logger]] 
.]] 
LogError]]  
(]]  !
ex]]! #
.]]# $
Message]]$ +
)]]+ ,
;]], -
throw^^ 
new^^ 
CustomException^^ )
(^^) *
MessageCodesApi^^* 9
.^^9 :
InvalidToken^^: F
,^^F G
ResponseType^^H T
.^^T U
Error^^U Z
,^^Z [
HttpStatusCode^^\ j
.^^j k
Unauthorized^^k w
)^^w x
;^^x y
}__ 
catch`` 
(`` ,
 SecurityTokenValidationException`` 3
ex``4 6
)``6 7
{aa 
_loggerbb 
.bb 
LogErrorbb  
(bb  !
exbb! #
.bb# $
Messagebb$ +
)bb+ ,
;bb, -
throwcc 
newcc 
CustomExceptioncc )
(cc) *
MessageCodesApicc* 9
.cc9 :
TokenExpiredcc: F
,ccF G
ResponseTypeccH T
.ccT U
ErrorccU Z
,ccZ [
HttpStatusCodecc\ j
.ccj k
Unauthorizedcck w
)ccw x
;ccx y
}dd 
}ee 	
publicgg 

TokenModelgg 
GetTokenModelgg '
(gg' (
HttpContextgg( 3
contextgg4 ;
)gg; <
{hh 	
tryii 
{jj 
varkk 
tokenkk 
=kk 
contextkk #
.kk# $
Requestkk$ +
.kk+ ,
Headerskk, 3
[kk3 4
$strkk4 C
]kkC D
.kkD E
FirstOrDefaultkkE S
(kkS T
)kkT U
?kkU V
.kkV W
SplitkkW \
(kk\ ]
$strkk] `
)kk` a
.kka b
Lastkkb f
(kkf g
)kkg h
;kkh i
ifll 
(ll 
tokenll 
==ll 
nullll !
)ll! "
throwmm 
newmm 
CustomExceptionmm -
(mm- .
MessageCodesApimm. =
.mm= >
WithOutTokenmm> J
,mmJ K
ResponseTypemmL X
.mmX Y
ErrormmY ^
,mm^ _
HttpStatusCodemm` n
.mmn o
Unauthorizedmmo {
)mm{ |
;mm| }
varnn 
tokenHandlernn  
=nn! "
newnn# &#
JwtSecurityTokenHandlernn' >
(nn> ?
)nn? @
;nn@ A
varoo 
jwtSecurityTokenoo $
=oo% &
tokenHandleroo' 3
.oo3 4
ReadJwtTokenoo4 @
(oo@ A
tokenooA F
)ooF G
;ooG H
varpp 
claimspp 
=pp 
jwtSecurityTokenpp -
.pp- .
Claimspp. 4
.pp4 5
ToListpp5 ;
(pp; <
)pp< =
;pp= >
varqq 
usernameqq 
=qq 
claimsqq %
.qq% &
FirstOrDefaultqq& 4
(qq4 5
cqq5 6
=>qq7 9
cqq: ;
.qq; <
Typeqq< @
==qqA C
nameofqqD J
(qqJ K
ModelsqqK Q
.qqQ R
EnumsqqR W
.qqW X
ClaimqqX ]
.qq] ^
Nameqq^ b
)qqb c
)qqc d
.qqd e
Valueqqe j
;qqj k
varrr 
emailrr 
=rr 
claimsrr "
.rr" #
FirstOrDefaultrr# 1
(rr1 2
crr2 3
=>rr4 6
crr7 8
.rr8 9
Typerr9 =
==rr> @
nameofrrA G
(rrG H
ModelsrrH N
.rrN O
EnumsrrO T
.rrT U
ClaimrrU Z
.rrZ [
Emailrr[ `
)rr` a
)rra b
.rrb c
Valuerrc h
;rrh i
varss 
idss 
=ss 
claimsss 
.ss  
FirstOrDefaultss  .
(ss. /
css/ 0
=>ss1 3
css4 5
.ss5 6
Typess6 :
==ss; =
nameofss> D
(ssD E
ModelsssE K
.ssK L
EnumsssL Q
.ssQ R
ClaimssR W
.ssW X
IdssX Z
)ssZ [
)ss[ \
.ss\ ]
Valuess] b
;ssb c
vartt 

tokenModeltt 
=tt  
newtt! $

TokenModeltt% /
(tt/ 0
)tt0 1
{uu 
Usernamevv 
=vv 
usernamevv '
,vv' (
Emailww 
=ww 
emailww !
,ww! "
Idxx 
=xx 
idxx 
}yy 
;yy 
returnzz 

tokenModelzz !
;zz! "
}{{ 
catch|| 
(|| 
	Exception|| 
ex|| 
)||  
{}} 
_logger~~ 
.~~ 
LogError~~  
(~~  !
ex~~! #
.~~# $
Message~~$ +
)~~+ ,
;~~, -
throw 
new 
CustomException )
() *
MessageCodesApi* 9
.9 :
InvalidParceToken: K
,K L
ResponseTypeM Y
.Y Z
ErrorZ _
,_ `
HttpStatusCodea o
.o p
Unauthorizedp |
)| }
;} ~
}
ÄÄ 
}
ÅÅ 	
private
ÉÉ 
bool
ÉÉ 
LifetimeValidator
ÉÉ &
(
ÉÉ& '
DateTime
ÉÉ' /
?
ÉÉ/ 0
	notBefore
ÉÉ1 :
,
ÉÉ: ;
DateTime
ÉÉ< D
?
ÉÉD E
expires
ÉÉF M
,
ÉÉM N
SecurityToken
ÉÉO \
securityToken
ÉÉ] j
,
ÉÉj k(
TokenValidationParametersÉÉl Ö$
validationParametersÉÉÜ ö
)ÉÉö õ
{
ÑÑ 	
return
ÖÖ 
(
ÖÖ 
expires
ÖÖ 
!=
ÖÖ 
null
ÖÖ #
&&
ÖÖ$ &
DateTime
ÖÖ' /
.
ÖÖ/ 0
UtcNow
ÖÖ0 6
<
ÖÖ7 8
expires
ÖÖ9 @
)
ÖÖ@ A
;
ÖÖA B
}
ÜÜ 	
}
áá 
}àà Ö
áC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Services\obj\Debug\net5.0\.NETCoreApp,Version=v5.0.AssemblyAttributes.cs
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
]| }ƒ
ÖC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Services\obj\Debug\net5.0\Dach.ElectionSystem.Services.AssemblyInfo.cs
[ 
assembly 	
:	 

System 
. 

Reflection 
. $
AssemblyCompanyAttribute 5
(5 6
$str6 T
)T U
]U V
[ 
assembly 	
:	 

System 
. 

Reflection 
. *
AssemblyConfigurationAttribute ;
(; <
$str< C
)C D
]D E
[ 
assembly 	
:	 

System 
. 

Reflection 
. (
AssemblyFileVersionAttribute 9
(9 :
$str: C
)C D
]D E
[ 
assembly 	
:	 

System 
. 

Reflection 
. 1
%AssemblyInformationalVersionAttribute B
(B C
$strC J
)J K
]K L
[ 
assembly 	
:	 

System 
. 

Reflection 
. $
AssemblyProductAttribute 5
(5 6
$str6 T
)T U
]U V
[ 
assembly 	
:	 

System 
. 

Reflection 
. "
AssemblyTitleAttribute 3
(3 4
$str4 R
)R S
]S T
[ 
assembly 	
:	 

System 
. 

Reflection 
. $
AssemblyVersionAttribute 5
(5 6
$str6 ?
)? @
]@ A