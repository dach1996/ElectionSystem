¶Q
aC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Services\Data\ValidateIntegrity.cs
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
 
Services

 &
.

& '
Data

' +
{ 
public 

class 
ValidateIntegrity "
{ 
private 
readonly 
IUserRepository (
userRepository) 7
;7 8
private 
readonly 
IVoteRepository (
voteRepository) 7
;7 8
private 
readonly 
IEventRepository )
eventRepository* 9
;9 :
private 
readonly  
ICandidateRepository -
candidateRepository. A
;A B
public 
ValidateIntegrity  
(  !
IUserRepository 
userRepository *
,* +
IVoteRepository 
voteRepository *
,* +
IEventRepository 
eventRepository ,
,, - 
ICandidateRepository  
candidateRepository! 4
)4 5
{ 	
this 
. 
userRepository 
=  !
userRepository" 0
;0 1
this 
. 
voteRepository 
=  !
voteRepository" 0
;0 1
this 
. 
eventRepository  
=! "
eventRepository# 2
;2 3
this 
. 
candidateRepository $
=% &
candidateRepository' :
;: ;
} 	
public** 
async** 
Task** 
<** 
Event** 
>**  
ValidateEvent**! .
(**. /
int**/ 2
id**3 5
)**5 6
{++ 	
var,, 

existEvent,, 
=,, 
await,, "
eventRepository,,# 2
.,,2 3
GetAsync,,3 ;
(,,; <
u,,< =
=>,,> @
u,,A B
.,,B C
Id,,C E
==,,F H
id,,I K
),,K L
;,,L M
if-- 
(-- 

existEvent-- 
.-- 
Count--  
(--  !
)--! "
!=--# %
$num--& '
)--' (
throw.. 
new.. 
CustomException.. )
(..) *
MessageCodesApi..* 9
...9 :
NotFindRecord..: G
,..G H
ResponseType..I U
...U V
Error..V [
,..[ \
HttpStatusCode..] k
...k l
NotFound..l t
,..t u
$"..v x-
 No se encuntra el evento con Id:	..x ò
{
..ò ô
id
..ô õ
}
..õ ú
"
..ú ù
)
..ù û
;
..û ü
var// 
eventCurrent// 
=// 

existEvent// )
.//) *
First//* /
(/// 0
)//0 1
;//1 2
if00 
(00 
eventCurrent00 
.00 
IsDelete00 %
)00% &
throw11 
new11 
CustomException11 )
(11) *
MessageCodesApi11* 9
.119 :
NotFindRecord11: G
,11G H
ResponseType11I U
.11U V
Error11V [
,11[ \
HttpStatusCode11] k
.11k l
NotFound11l t
,11t u
$"11v x
El evento con Id:	11x â
{
11â ä
id
11ä å
}
11å ç
 ha sido borrado
11ç ù
"
11ù û
)
11û ü
;
11ü †
return22 

existEvent22 
.22 
FirstOrDefault22 ,
(22, -
)22- .
;22. /
}33 	
public55 
async55 
Task55 
<55 
User55 
>55 
ValidateUser55  ,
(55, -
int55- 0
idUser551 7
)557 8
{66 	
var77 
	existUser77 
=77 
await77 !
userRepository77" 0
.770 1
GetAsync771 9
(779 :
u77: ;
=>77< >
u77? @
.77@ A
Id77A C
==77D F
idUser77G M
)77M N
;77N O
if88 
(88 
	existUser88 
.88 
Count88 
(88  
)88  !
!=88" $
$num88% &
)88& '
throw99 
new99 
CustomException99 )
(99) *
MessageCodesApi99* 9
.999 :
NotFindRecord99: G
,99G H
ResponseType99I U
.99U V
Error99V [
,99[ \
HttpStatusCode99] k
.99k l
Unauthorized99l x
,99x y
$"99z |.
!No se encuntra el Usuario con Id:	99| ù
{
99ù û
idUser
99û §
}
99§ •
"
99• ¶
)
99¶ ß
;
99ß ®
return:: 
	existUser:: 
.:: 
FirstOrDefault:: +
(::+ ,
)::, -
;::- .
};; 	
public== 
async== 
Task== 
<== 
User== 
>== 
ValidateUser==  ,
(==, -
IRequestBase==- 9
request==: A
)==A B
{>> 	
var?? 
	existUser?? 
=?? 
await?? !
userRepository??" 0
.??0 1
GetAsync??1 9
(??9 :
u??: ;
=>??< >
u??? @
.??@ A
Id??A C
==??D F
System??G M
.??M N
Convert??N U
.??U V
ToInt32??V ]
(??] ^
request??^ e
.??e f

TokenModel??f p
.??p q
Id??q s
)??s t
&&??u w
u@@@ A
.@@A B
UserName@@B J
==@@K M
request@@N U
.@@U V

TokenModel@@V `
.@@` a
Username@@a i
&&@@j l
uAA@ A
.AAA B
EmailAAB G
==AAH J
requestAAK R
.AAR S

TokenModelAAS ]
.AA] ^
EmailAA^ c
,AAc d
includePropertiesBB@ Q
:BBQ R
$"BBS U
{BBU V
nameofBBV \
(BB\ ]
UserBB] a
.BBa b"
ListEventAdministratorBBb x
)BBx y
}BBy z
,BBz {
{BB{ |
nameof	BB| Ç
(
BBÇ É
User
BBÉ á
.
BBá à
EventNumber
BBà ì
)
BBì î
}
BBî ï
"
BBï ñ
)
BBñ ó
;
BBó ò
ifCC 
(CC 
	existUserCC 
.CC 
CountCC 
(CC  
)CC  !
!=CC" $
$numCC% &
)CC& '
throwDD 
newDD 
CustomExceptionDD )
(DD) *
MessageCodesApiDD* 9
.DD9 :
DataInconsistencyDD: K
,DDK L
ResponseTypeDDM Y
.DDY Z
ErrorDDZ _
,DD_ `
HttpStatusCodeDDa o
.DDo p
UnauthorizedDDp |
,DD| }
$"	DD~ Ä0
"No se encuntra usuario con correo:
DDÄ ¢
{
DD¢ £
request
DD£ ™
.
DD™ ´

TokenModel
DD´ µ
.
DDµ ∂
Email
DD∂ ª
}
DDª º
"
DDº Ω
)
DDΩ æ
;
DDæ ø
returnEE 
	existUserEE 
.EE 
FirstOrDefaultEE +
(EE+ ,
)EE, -
;EE- .
}FF 	
publicHH 
asyncHH 
TaskHH 
<HH 
VoteHH 
>HH 
ValidateVoteHH  ,
(HH, -
intHH- 0
idHH1 3
)HH3 4
{II 	
varJJ 
	existVoteJJ 
=JJ 
awaitJJ !
voteRepositoryJJ" 0
.JJ0 1
GetAsyncJJ1 9
(JJ9 :
uJJ: ;
=>JJ< >
uJJ? @
.JJ@ A
IdJJA C
==JJD F
idJJG I
)JJI J
;JJJ K
ifKK 
(KK 
	existVoteKK 
.KK 
CountKK 
(KK  
)KK  !
!=KK" $
$numKK% &
)KK& '
throwLL 
newLL 
CustomExceptionLL )
(LL) *
MessageCodesApiLL* 9
.LL9 :
NotFindRecordLL: G
,LLG H
ResponseTypeLLI U
.LLU V
ErrorLLV [
,LL[ \
HttpStatusCodeLL] k
.LLk l
NotFoundLLl t
,LLt u
$"LLv x+
No se encuntra el voto con Id:	LLx ñ
{
LLñ ó
id
LLó ô
}
LLô ö
"
LLö õ
)
LLõ ú
;
LLú ù
returnMM 
	existVoteMM 
.MM 
FirstOrDefaultMM +
(MM+ ,
)MM, -
;MM- .
}NN 	
publicPP 
asyncPP 
TaskPP 
<PP 
	CandidatePP #
>PP# $
ValidateCandiatePP% 5
(PP5 6
intPP6 9
idPP: <
)PP< =
{QQ 	
varRR 
existCandidateRR 
=RR  
awaitRR! &
candidateRepositoryRR' :
.RR: ;
GetAsyncIncludeRR; J
(RRJ K
uRRK L
=>RRM O
uRRP Q
.RRQ R
IdRRR T
==RRU W
idRRX Z
,SSL M
includePropertiesSSN _
:SS_ `
uSSa b
=>SSc e
$"SSf h
{SSh i
nameofSSi o
(SSo p
uSSp q
.SSq r
UserSSr v
)SSv w
}SSw x
"SSx y
)SSy z
;SSz {
ifTT 
(TT 
existCandidateTT 
.TT 
CountTT $
(TT$ %
)TT% &
!=TT' )
$numTT* +
)TT+ ,
throwUU 
newUU 
CustomExceptionUU )
(UU) *
MessageCodesApiUU* 9
.UU9 :
NotFindRecordUU: G
,UUG H
ResponseTypeUUI U
.UUU V
ErrorUUV [
,UU[ \
HttpStatusCodeUU] k
.UUk l
NotFoundUUl t
,UUt u
$"UUv x0
#No se encuntra el candidato con Id:	UUx õ
{
UUõ ú
id
UUú û
}
UUû ü
"
UUü †
)
UU† °
;
UU° ¢
returnVV 
existCandidateVV !
.VV! "
FirstOrDefaultVV" 0
(VV0 1
)VV1 2
;VV2 3
}WW 	
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
} p
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
{HH 
_loggerII 
.II 
LogII 
(II 
LogLevelII $
.II$ %
ErrorII% *
,II* +
$"II, .
Estoy en TokenII. <
"II< =
)II= >
;II> ?
varJJ 
tokenJJ 
=JJ 
contextJJ #
.JJ# $
RequestJJ$ +
.JJ+ ,
HeadersJJ, 3
[JJ3 4
$strJJ4 C
]JJC D
.JJD E
FirstOrDefaultJJE S
(JJS T
)JJT U
?JJU V
.JJV W
SplitJJW \
(JJ\ ]
$strJJ] `
)JJ` a
.JJa b
LastJJb f
(JJf g
)JJg h
;JJh i
ifKK 
(KK 
tokenKK 
==KK 
nullKK !
)KK! "
throwLL 
newLL 
CustomExceptionLL -
(LL- .
MessageCodesApiLL. =
.LL= >
WithOutTokenLL> J
,LLJ K
ResponseTypeLLL X
.LLX Y
ErrorLLY ^
,LL^ _
HttpStatusCodeLL` n
.LLn o
UnauthorizedLLo {
)LL{ |
;LL| }
varMM 
tokenHandlerMM  
=MM! "
newMM# &#
JwtSecurityTokenHandlerMM' >
(MM> ?
)MM? @
;MM@ A
varNN 
keyNN 
=NN 
EncodingNN "
.NN" #
ASCIINN# (
.NN( )
GetBytesNN) 1
(NN1 2
	secretKeyNN2 ;
)NN; <
;NN< =
tokenHandlerOO 
.OO 
ValidateTokenOO *
(OO* +
tokenOO+ 0
,OO0 1
newOO2 5%
TokenValidationParametersOO6 O
{PP 
ValidateIssuerQQ "
=QQ# $
falseQQ% *
,QQ* +
ValidateAudienceRR $
=RR% &
falseRR' ,
,RR, -
ValidateLifetimeSS $
=SS% &
trueSS' +
,SS+ ,$
ValidateIssuerSigningKeyTT ,
=TT- .
trueTT/ 3
,TT3 4
LifetimeValidatorUU %
=UU& '
thisUU( ,
.UU, -
LifetimeValidatorUU- >
,UU> ?
IssuerSigningKeyVV $
=VV% &
newVV' * 
SymmetricSecurityKeyVV+ ?
(VV? @
keyVV@ C
)VVC D
}WW 
,WW 
outWW 
SecurityTokenWW $
validatedTokenWW% 3
)WW3 4
;WW4 5
}ZZ 
catch[[ 
([[ 
ArgumentException[[ $
ex[[% '
)[[' (
{]] 
_logger^^ 
.^^ 
LogError^^  
(^^  !
ex^^! #
.^^# $
Message^^$ +
)^^+ ,
;^^, -
throw__ 
new__ 
CustomException__ )
(__) *
MessageCodesApi__* 9
.__9 :
InvalidToken__: F
,__F G
ResponseType__H T
.__T U
Error__U Z
,__Z [
HttpStatusCode__\ j
.__j k
Unauthorized__k w
)__w x
;__x y
}`` 
catchaa 
(aa ,
 SecurityTokenValidationExceptionaa 3
exaa4 6
)aa6 7
{bb 
_loggercc 
.cc 
LogErrorcc  
(cc  !
excc! #
.cc# $
Messagecc$ +
)cc+ ,
;cc, -
throwdd 
newdd 
CustomExceptiondd )
(dd) *
MessageCodesApidd* 9
.dd9 :
TokenExpireddd: F
,ddF G
ResponseTypeddH T
.ddT U
ErrorddU Z
,ddZ [
HttpStatusCodedd\ j
.ddj k
Unauthorizedddk w
)ddw x
;ddx y
}ee 
}ff 	
publichh 

TokenModelhh 
GetTokenModelhh '
(hh' (
HttpContexthh( 3
contexthh4 ;
)hh; <
{ii 	
tryjj 
{kk 
varll 
tokenll 
=ll 
contextll #
.ll# $
Requestll$ +
.ll+ ,
Headersll, 3
[ll3 4
$strll4 C
]llC D
.llD E
FirstOrDefaultllE S
(llS T
)llT U
?llU V
.llV W
SplitllW \
(ll\ ]
$strll] `
)ll` a
.lla b
Lastllb f
(llf g
)llg h
;llh i
ifmm 
(mm 
tokenmm 
==mm 
nullmm !
)mm! "
thrownn 
newnn 
CustomExceptionnn -
(nn- .
MessageCodesApinn. =
.nn= >
WithOutTokennn> J
,nnJ K
ResponseTypennL X
.nnX Y
ErrornnY ^
,nn^ _
HttpStatusCodenn` n
.nnn o
Unauthorizednno {
)nn{ |
;nn| }
varoo 
tokenHandleroo  
=oo! "
newoo# &#
JwtSecurityTokenHandleroo' >
(oo> ?
)oo? @
;oo@ A
varpp 
jwtSecurityTokenpp $
=pp% &
tokenHandlerpp' 3
.pp3 4
ReadJwtTokenpp4 @
(pp@ A
tokenppA F
)ppF G
;ppG H
varqq 
claimsqq 
=qq 
jwtSecurityTokenqq -
.qq- .
Claimsqq. 4
.qq4 5
ToListqq5 ;
(qq; <
)qq< =
;qq= >
varrr 
usernamerr 
=rr 
claimsrr %
.rr% &
FirstOrDefaultrr& 4
(rr4 5
crr5 6
=>rr7 9
crr: ;
.rr; <
Typerr< @
==rrA C
nameofrrD J
(rrJ K
ModelsrrK Q
.rrQ R
EnumsrrR W
.rrW X
ClaimrrX ]
.rr] ^
Namerr^ b
)rrb c
)rrc d
.rrd e
Valuerre j
;rrj k
varss 
emailss 
=ss 
claimsss "
.ss" #
FirstOrDefaultss# 1
(ss1 2
css2 3
=>ss4 6
css7 8
.ss8 9
Typess9 =
==ss> @
nameofssA G
(ssG H
ModelsssH N
.ssN O
EnumsssO T
.ssT U
ClaimssU Z
.ssZ [
Emailss[ `
)ss` a
)ssa b
.ssb c
Valuessc h
;ssh i
vartt 
idtt 
=tt 
claimstt 
.tt  
FirstOrDefaulttt  .
(tt. /
ctt/ 0
=>tt1 3
ctt4 5
.tt5 6
Typett6 :
==tt; =
nameoftt> D
(ttD E
ModelsttE K
.ttK L
EnumsttL Q
.ttQ R
ClaimttR W
.ttW X
IdttX Z
)ttZ [
)tt[ \
.tt\ ]
Valuett] b
;ttb c
varuu 

tokenModeluu 
=uu  
newuu! $

TokenModeluu% /
(uu/ 0
)uu0 1
{vv 
Usernameww 
=ww 
usernameww '
,ww' (
Emailxx 
=xx 
emailxx !
,xx! "
Idyy 
=yy 
idyy 
}zz 
;zz 
return{{ 

tokenModel{{ !
;{{! "
}|| 
catch}} 
(}} 
	Exception}} 
ex}} 
)}}  
{~~ 
_logger 
. 
LogError  
(  !
ex! #
.# $
Message$ +
)+ ,
;, -
throw
ÄÄ 
new
ÄÄ 
CustomException
ÄÄ )
(
ÄÄ) *
MessageCodesApi
ÄÄ* 9
.
ÄÄ9 :
InvalidParceToken
ÄÄ: K
,
ÄÄK L
ResponseType
ÄÄM Y
.
ÄÄY Z
Error
ÄÄZ _
,
ÄÄ_ `
HttpStatusCode
ÄÄa o
.
ÄÄo p
Unauthorized
ÄÄp |
)
ÄÄ| }
;
ÄÄ} ~
}
ÅÅ 
}
ÇÇ 	
private
ÑÑ 
bool
ÑÑ 
LifetimeValidator
ÑÑ &
(
ÑÑ& '
DateTime
ÑÑ' /
?
ÑÑ/ 0
	notBefore
ÑÑ1 :
,
ÑÑ: ;
DateTime
ÑÑ< D
?
ÑÑD E
expires
ÑÑF M
,
ÑÑM N
SecurityToken
ÑÑO \
securityToken
ÑÑ] j
,
ÑÑj k(
TokenValidationParametersÑÑl Ö$
validationParametersÑÑÜ ö
)ÑÑö õ
{
ÖÖ 	
return
ÜÜ 
(
ÜÜ 
expires
ÜÜ 
!=
ÜÜ 
null
ÜÜ #
&&
ÜÜ$ &
DateTime
ÜÜ' /
.
ÜÜ/ 0
UtcNow
ÜÜ0 6
<
ÜÜ7 8
expires
ÜÜ9 @
)
ÜÜ@ A
;
ÜÜA B
}
áá 	
}
àà 
}ââ á
âC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Services\obj\Release\net5.0\.NETCoreApp,Version=v5.0.AssemblyAttributes.cs
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
]| }∆
áC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Services\obj\Release\net5.0\Dach.ElectionSystem.Services.AssemblyInfo.cs
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
$str< E
)E F
]F G
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