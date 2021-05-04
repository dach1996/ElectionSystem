Ù
cC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.WebApi\Controllers\AuthController.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
WebApi $
.$ %

Properties% /
{		 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
AuthController 
:  !
ApiControllerBase" 3
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public 
AuthController 
( 
	IMediator '
mediator( 0
)0 1
{ 	
	_mediator 
= 
mediator  
;  !
} 	
[ 	
HttpPost	 
] 
[ 	 
ProducesResponseType	 
( 
$num !
,! "
Type# '
=( )
typeof* 0
(0 1
GenericResponse1 @
<@ A
LoginResponseA N
>N O
)O P
)P Q
]Q R
[ 	 
ProducesResponseType	 
( 
$num !
,! "
Type# '
=( )
typeof* 0
(0 1
GenericResponse1 @
<@ A
stringA G
>G H
)H I
)I J
]J K
[   	 
ProducesResponseType  	 
(   
$num   !
,  ! "
Type  # '
=  ( )
typeof  * 0
(  0 1
GenericResponse  1 @
<  @ A
string  A G
>  G H
)  H I
)  I J
]  J K
[!! 	
Route!!	 
(!! 
$str!! 
)!! 
]!! 
public"" 
async"" 
Task"" 
<"" 
IActionResult"" '
>""' (
Auth"") -
(""- .
LoginRequest"". :
requestLogin""; G
)""G H
=>##	 
Success## 
(## 
await## 
	_mediator## #
.### $
Send##$ (
(##( )
requestLogin##) 5
)##5 6
)##6 7
;##7 8
[(( 	
HttpPost((	 
](( 
[)) 	 
ProducesResponseType))	 
()) 
$num)) !
,))! "
Type))# '
=))( )
typeof))* 0
())0 1
GenericResponse))1 @
<))@ A
Unit))A E
>))E F
)))F G
)))G H
]))H I
[** 	 
ProducesResponseType**	 
(** 
$num** !
,**! "
Type**# '
=**( )
typeof*** 0
(**0 1
GenericResponse**1 @
<**@ A
string**A G
>**G H
)**H I
)**I J
]**J K
[++ 	 
ProducesResponseType++	 
(++ 
$num++ !
,++! "
Type++# '
=++( )
typeof++* 0
(++0 1
GenericResponse++1 @
<++@ A
string++A G
>++G H
)++H I
)++I J
]++J K
[,, 	
Route,,	 
(,, 
$str,, "
),," #
],,# $
public-- 
async-- 
Task-- 
<-- 
IActionResult-- '
>--' (
ForgottenPassword--) :
(--: ;$
ForggotenPasswordRequest--; S
requestLogin--T `
)--` a
=>..	 
Success.. 
(.. 
await.. 
	_mediator.. #
...# $
Send..$ (
(..( )
requestLogin..) 5
)..5 6
)..6 7
;..7 8
}11 
}22 ŸC
hC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.WebApi\Controllers\CandidateController.cs
	namespace		 	
Dach		
 
.		 
ElectionSystem		 
.		 
WebApi		 $
.		$ %
Controllers		% 0
{

 
[ 
Route 

(
 
$str ,
), -
]- .
[ 
ApiController 
] 
[ 
ServiceFilter 
( 
typeof 
(  
ModelFilterAttribute .
). /
)/ 0
]0 1
public 

class 
CandidateController $
:% &
ApiControllerBase' 8
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public 
CandidateController "
(" #
	IMediator# ,
mediator- 5
)5 6
=>7 9
	_mediator 
= 
mediator  
;  !
[ 	
HttpPost	 
] 
[ 	 
ProducesResponseType	 
( 
$num !
,! "
Type# '
=( )
typeof* 0
(0 1#
CandidateCreateResponse1 H
)H I
)I J
]J K
[ 	 
ProducesResponseType	 
( 
$num !
,! "
Type# '
=( )
typeof* 0
(0 1
GenericResponse1 @
<@ A
stringA G
>G H
)H I
)I J
]J K
[   	 
ProducesResponseType  	 
(   
$num   !
,  ! "
Type  # '
=  ( )
typeof  * 0
(  0 1
GenericResponse  1 @
<  @ A
string  A G
>  G H
)  H I
)  I J
]  J K
public!! 
async!! 
Task!! 
<!! 
IActionResult!! '
>!!' (
CreateCandidate!!) 8
(!!8 9
["" 
FromBody"" 
]"" "
CandidateCreateRequest"" -
request"". 5
,""5 6
[## 
	FromRoute## 
]## 
int## 
idEvent## #
)##$ %
{$$ 	
request%% 
.%% 
IdEvent%% 
=%% 
idEvent%% %
;%%% &
return&& 
Success&& 
(&& 
await&&  
	_mediator&&! *
.&&* +
Send&&+ /
(&&/ 0
request&&0 7
)&&7 8
)&&8 9
;&&9 :
}'' 	
[00 	

HttpDelete00	 
]00 
[11 	
Route11	 
(11 
$str11 
)11 
]11  
[22 	 
ProducesResponseType22	 
(22 
$num22 !
,22! "
Type22# '
=22( )
typeof22* 0
(220 1#
CandidateDeleteResponse221 H
)22H I
)22I J
]22J K
[33 	 
ProducesResponseType33	 
(33 
$num33 !
,33! "
Type33# '
=33( )
typeof33* 0
(330 1
GenericResponse331 @
<33@ A
string33A G
>33G H
)33H I
)33I J
]33J K
[44 	 
ProducesResponseType44	 
(44 
$num44 !
,44! "
Type44# '
=44( )
typeof44* 0
(440 1
GenericResponse441 @
<44@ A
string44A G
>44G H
)44H I
)44I J
]44J K
public55 
async55 
Task55 
<55 
IActionResult55 '
>55' (
DesactiveCandidate55) ;
(55; <
[66 
	FromQuery66 
]66 "
CandidateDeleteRequest66 .
request66/ 6
,666 7
[77 
	FromRoute77 
]77 
int77 
?77 
idEvent77 $
,77$ %
[88 
	FromRoute88 
]88 
int88 
?88 
idCandidate88 (
)88( )
{99 	
request:: 
.:: 
IdEvent:: 
=:: 
idEvent:: %
;::% &
request;; 
.;; 
IdCandidate;; 
=;;  !
idCandidate;;" -
;;;- .
return<< 
Success<< 
(<< 
await<<  
	_mediator<<! *
.<<* +
Send<<+ /
(<</ 0
request<<0 7
)<<7 8
)<<8 9
;<<9 :
}== 	
[FF 	
HttpPutFF	 
]FF 
[GG 	
RouteGG	 
(GG 
$strGG 
)GG 
]GG  
[HH 	 
ProducesResponseTypeHH	 
(HH 
$numHH !
,HH! "
TypeHH# '
=HH( )
typeofHH* 0
(HH0 1#
CandidateUpdateResponseHH1 H
)HHH I
)HHI J
]HHJ K
[II 	 
ProducesResponseTypeII	 
(II 
$numII !
,II! "
TypeII# '
=II( )
typeofII* 0
(II0 1
GenericResponseII1 @
<II@ A
stringIIA G
>IIG H
)IIH I
)III J
]IIJ K
[JJ 	 
ProducesResponseTypeJJ	 
(JJ 
$numJJ !
,JJ! "
TypeJJ# '
=JJ( )
typeofJJ* 0
(JJ0 1
GenericResponseJJ1 @
<JJ@ A
stringJJA G
>JJG H
)JJH I
)JJI J
]JJJ K
publicKK 
asyncKK 
TaskKK 
<KK 
IActionResultKK '
>KK' (
UpdateCandidateKK) 8
(KK8 9
[LL 
FromBodyLL 
]LL "
CandidateUpdateRequestLL -
requestLL. 5
,LL5 6
[MM 
	FromRouteMM 
]MM 
intMM 
idEventMM #
,MM# $
[NN 
	FromRouteNN 
]NN 
intNN 
idCandidateNN '
)NN' (
{OO 	
requestPP 
.PP 
IdCandidatePP 
=PP  !
idCandidatePP" -
;PP- .
requestQQ 
.QQ 
IdEventQQ 
=QQ 
idEventQQ %
;QQ% &
returnRR 
SuccessRR 
(RR 
awaitRR  
	_mediatorRR! *
.RR* +
SendRR+ /
(RR/ 0
requestRR0 7
)RR7 8
)RR8 9
;RR9 :
}SS 	
[]] 	
HttpGet]]	 
]]] 
[^^ 	 
ProducesResponseType^^	 
(^^ 
$num^^ !
,^^! "
Type^^# '
=^^( )
typeof^^* 0
(^^0 1 
CandidateGetResponse^^1 E
)^^E F
)^^F G
]^^G H
[__ 	 
ProducesResponseType__	 
(__ 
$num__ !
,__! "
Type__# '
=__( )
typeof__* 0
(__0 1
GenericResponse__1 @
<__@ A
string__A G
>__G H
)__H I
)__I J
]__J K
[`` 	 
ProducesResponseType``	 
(`` 
$num`` !
,``! "
Type``# '
=``( )
typeof``* 0
(``0 1
GenericResponse``1 @
<``@ A
string``A G
>``G H
)``H I
)``I J
]``J K
[aa 	
Routeaa	 
(aa 
$straa 
)aa 
]aa  
[bb 	
Routebb	 
(bb 
$strbb 
)bb 
]bb 
publiccc 
asynccc 
Taskcc 
<cc 
IActionResultcc '
>cc' (

GetHandlercc) 3
(cc3 4
[dd	 

	FromQuerydd
 
]dd 
CandidateGetRequestdd (
requestdd) 0
,dd0 1
[ee	 

	FromRouteee
 
]ee 
intee 
?ee 
idEventee !
,ee! "
[ff	 

	FromRouteff
 
]ff 
intff 
?ff 
idCandidateff %
)ff% &
{gg 	
requesthh 
.hh 
IdEventhh 
=hh 
idEventhh %
;hh% &
requestii 
.ii 
IdCandidateii 
=ii  !
idCandidateii" -
;ii- .
returnjj 
Successjj 
(jj 
awaitjj  
	_mediatorjj! *
.jj* +
Sendjj+ /
(jj/ 0
requestjj0 7
)jj7 8
)jj8 9
;jj9 :
}kk 	
}mm 
}nn ˙C
qC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.WebApi\Controllers\EventAdministratorController.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
WebApi $
.$ %
Controllers% 0
{ 
[ 
Route 

(
 
$str $
)$ %
]% &
[ 
ApiController 
] 
[ 
ServiceFilter 
( 
typeof 
(  
ModelFilterAttribute .
). /
)/ 0
]0 1
public 

class (
EventAdministratorController -
:. /
ApiControllerBase0 A
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public (
EventAdministratorController +
(+ ,
	IMediator, 5
mediator6 >
)> ?
{ 	
	_mediator 
= 
mediator  
;  !
} 	
[## 	
HttpPost##	 
]## 
[$$ 	
Route$$	 
($$ 
$str$$ )
)$$) *
]$$* +
[%% 	 
ProducesResponseType%%	 
(%% 
$num%% !
,%%! "
Type%%# '
=%%( )
typeof%%* 0
(%%0 1,
 EventAdministratorCreateResponse%%1 Q
)%%Q R
)%%R S
]%%S T
[&& 	 
ProducesResponseType&&	 
(&& 
$num&& !
,&&! "
Type&&# '
=&&( )
typeof&&* 0
(&&0 1
GenericResponse&&1 @
<&&@ A
string&&A G
>&&G H
)&&H I
)&&I J
]&&J K
['' 	 
ProducesResponseType''	 
('' 
$num'' !
,''! "
Type''# '
=''( )
typeof''* 0
(''0 1
GenericResponse''1 @
<''@ A
string''A G
>''G H
)''H I
)''I J
]''J K
public(( 
async(( 
Task(( 
<(( 
IActionResult(( '
>((' ($
CreateEventAdministrator(() A
(((A B
[)) 
	FromRoute)) 
])) 
int)) 
idEvent)) #
,))# $
[** 
	FromRoute** 
]** 
int** 
idUser** "
,**" #
[++ 
FromBody++ 
]++ +
EventAdministratorCreateRequest++ 6
request++7 >
)++> ?
{-- 	
request.. 
... 
IdEvent.. 
=.. 
idEvent.. %
;..% &
request// 
.// 
IdUser// 
=// 
idUser// #
;//# $
return00 
Success00 
(00 
await00  
	_mediator00! *
.00* +
Send00+ /
(00/ 0
request000 7
)007 8
)008 9
;009 :
}11 	
[:: 	

HttpDelete::	 
]:: 
[;; 	
Route;;	 
(;; 
$str;; )
);;) *
];;* +
[<< 	 
ProducesResponseType<<	 
(<< 
$num<< !
,<<! "
Type<<# '
=<<( )
typeof<<* 0
(<<0 1,
 EventAdministratorDeleteResponse<<1 Q
)<<Q R
)<<R S
]<<S T
[== 	 
ProducesResponseType==	 
(== 
$num== !
,==! "
Type==# '
===( )
typeof==* 0
(==0 1
GenericResponse==1 @
<==@ A
string==A G
>==G H
)==H I
)==I J
]==J K
[>> 	 
ProducesResponseType>>	 
(>> 
$num>> !
,>>! "
Type>># '
=>>( )
typeof>>* 0
(>>0 1
GenericResponse>>1 @
<>>@ A
string>>A G
>>>G H
)>>H I
)>>I J
]>>J K
public?? 
async?? 
Task?? 
<?? 
IActionResult?? '
>??' ('
DesactiveEventAdministrator??) D
(??D E
[@@ 
	FromRoute@@ 
]@@ 
int@@ 
idEvent@@ #
,@@# $
[AA 
	FromRouteAA 
]AA 
intAA 
idUserAA "
,AA" #
[BB 
FromBodyBB 
]BB +
EventAdministratorDeleteRequestBB 6
requestBB7 >
)BB> ?
{DD 	
requestEE 
.EE 
IdEventEE 
=EE 
idEventEE %
;EE% &
requestFF 
.FF 
IdUserFF 
=FF 
idUserFF #
;FF# $
returnGG 
SuccessGG 
(GG 
awaitGG  
	_mediatorGG! *
.GG* +
SendGG+ /
(GG/ 0
requestGG0 7
)GG7 8
)GG8 9
;GG9 :
}HH 	
[QQ 	
HttpPutQQ	 
]QQ 
[RR 	
RouteRR	 
(RR 
$strRR )
)RR) *
]RR* +
[SS 	 
ProducesResponseTypeSS	 
(SS 
$numSS !
,SS! "
TypeSS# '
=SS( )
typeofSS* 0
(SS0 1,
 EventAdministratorUpdateResponseSS1 Q
)SSQ R
)SSR S
]SSS T
[TT 	 
ProducesResponseTypeTT	 
(TT 
$numTT !
,TT! "
TypeTT# '
=TT( )
typeofTT* 0
(TT0 1
GenericResponseTT1 @
<TT@ A
stringTTA G
>TTG H
)TTH I
)TTI J
]TTJ K
[UU 	 
ProducesResponseTypeUU	 
(UU 
$numUU !
,UU! "
TypeUU# '
=UU( )
typeofUU* 0
(UU0 1
GenericResponseUU1 @
<UU@ A
stringUUA G
>UUG H
)UUH I
)UUI J
]UUJ K
publicVV 
asyncVV 
TaskVV 
<VV 
IActionResultVV '
>VV' ($
UpdateEventAdministratorVV) A
(VVA B
[WW 
	FromRouteWW 
]WW 
intWW 
idEventWW #
,WW# $
[XX 
	FromRouteXX 
]XX 
intXX 
idUserXX "
,XX" #
[YY 
FromBodyYY 
]YY +
EventAdministratorUpdateRequestYY 6
requestYY7 >
)YY> ?
{[[ 	
request\\ 
.\\ 
IdEvent\\ 
=\\ 
idEvent\\ %
;\\% &
request]] 
.]] 
IdUser]] 
=]] 
idUser]] #
;]]# $
return^^ 
Success^^ 
(^^ 
await^^  
	_mediator^^! *
.^^* +
Send^^+ /
(^^/ 0
request^^0 7
)^^7 8
)^^8 9
;^^9 :
}__ 	
[hh 	
HttpGethh	 
]hh 
[ii 	 
ProducesResponseTypeii	 
(ii 
$numii !
,ii! "
Typeii# '
=ii( )
typeofii* 0
(ii0 1)
EventAdministratorGetResponseii1 N
)iiN O
)iiO P
]iiP Q
[jj 	 
ProducesResponseTypejj	 
(jj 
$numjj !
,jj! "
Typejj# '
=jj( )
typeofjj* 0
(jj0 1
GenericResponsejj1 @
<jj@ A
stringjjA G
>jjG H
)jjH I
)jjI J
]jjJ K
[kk 	 
ProducesResponseTypekk	 
(kk 
$numkk !
,kk! "
Typekk# '
=kk( )
typeofkk* 0
(kk0 1
GenericResponsekk1 @
<kk@ A
stringkkA G
>kkG H
)kkH I
)kkI J
]kkJ K
[ll 	
Routell	 
(ll 
$strll 
)ll 
]ll 
publicmm 
asyncmm 
Taskmm 
<mm 
IActionResultmm '
>mm' (

GetHandlermm) 3
(mm3 4
[nn 
	FromRoutenn 
]nn 
intnn 
idEventnn #
,nn# $
[oo 
FromBodyoo 
]oo (
EventAdministratorGetRequestoo 3
requestoo4 ;
)oo; <
{qq 	
requestrr 
.rr 
IdEventrr 
=rr 
idEventrr %
;rr% &
returnss 
Successss 
(ss 
awaitss  
	_mediatorss! *
.ss* +
Sendss+ /
(ss/ 0
requestss0 7
)ss7 8
)ss8 9
;ss9 :
}tt 	
}xx 
}yy Ì9
dC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.WebApi\Controllers\EventController.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
WebApi $
.$ %
Controllers% 0
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
[ 
ServiceFilter 
( 
typeof 
(  
ModelFilterAttribute .
). /
)/ 0
]0 1
public 

class 
EventController  
:! "
ApiControllerBase# 4
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public 
EventController 
( 
	IMediator (
mediator) 1
)1 2
{ 	
	_mediator 
= 
mediator  
;  !
} 	
[!! 	
HttpPost!!	 
]!! 
["" 	 
ProducesResponseType""	 
("" 
$num"" !
,""! "
Type""# '
=""( )
typeof""* 0
(""0 1
EventCreateResponse""1 D
)""D E
)""E F
]""F G
[## 	 
ProducesResponseType##	 
(## 
$num## !
,##! "
Type### '
=##( )
typeof##* 0
(##0 1
GenericResponse##1 @
<##@ A
string##A G
>##G H
)##H I
)##I J
]##J K
[$$ 	 
ProducesResponseType$$	 
($$ 
$num$$ !
,$$! "
Type$$# '
=$$( )
typeof$$* 0
($$0 1
GenericResponse$$1 @
<$$@ A
string$$A G
>$$G H
)$$H I
)$$I J
]$$J K
public%% 
async%% 
Task%% 
<%% 
IActionResult%% '
>%%' (
CreateEvent%%) 4
(%%4 5
[%%5 6
FromBody%%6 >
]%%> ?
EventCreateRequest%%@ R
request%%S Z
)%%Z [
=>%%\ ^
Success%%_ f
(%%f g
await%%g l
	_mediator%%m v
.%%v w
Send%%w {
(%%{ |
request	%%| É
)
%%É Ñ
)
%%Ñ Ö
;
%%Ö Ü
[-- 	

HttpDelete--	 
]-- 
[.. 	
Route..	 
(.. 
$str.. 
).. 
].. 
[// 	 
ProducesResponseType//	 
(// 
$num// !
,//! "
Type//# '
=//( )
typeof//* 0
(//0 1
EventDeleteResponse//1 D
)//D E
)//E F
]//F G
[00 	 
ProducesResponseType00	 
(00 
$num00 !
,00! "
Type00# '
=00( )
typeof00* 0
(000 1
GenericResponse001 @
<00@ A
string00A G
>00G H
)00H I
)00I J
]00J K
[11 	 
ProducesResponseType11	 
(11 
$num11 !
,11! "
Type11# '
=11( )
typeof11* 0
(110 1
GenericResponse111 @
<11@ A
string11A G
>11G H
)11H I
)11I J
]11J K
public22 
async22 
Task22 
<22 
IActionResult22 '
>22' (
DesactiveEvent22) 7
(227 8
[228 9
	FromRoute229 B
]22B C
EventDeleteRequest22D V
request22W ^
)22^ _
=>22` b
Success22c j
(22j k
await22k p
	_mediator22q z
.22z {
Send22{ 
(	22 Ä
request
22Ä á
)
22á à
)
22à â
;
22â ä
[:: 	
HttpPut::	 
]:: 
[;; 	
Route;;	 
(;; 
$str;; 
);; 
];; 
[<< 	 
ProducesResponseType<<	 
(<< 
$num<< !
,<<! "
Type<<# '
=<<( )
typeof<<* 0
(<<0 1
EventUpdateResponse<<1 D
)<<D E
)<<E F
]<<F G
[== 	 
ProducesResponseType==	 
(== 
$num== !
,==! "
Type==# '
===( )
typeof==* 0
(==0 1
GenericResponse==1 @
<==@ A
string==A G
>==G H
)==H I
)==I J
]==J K
[>> 	 
ProducesResponseType>>	 
(>> 
$num>> !
,>>! "
Type>># '
=>>( )
typeof>>* 0
(>>0 1
GenericResponse>>1 @
<>>@ A
string>>A G
>>>G H
)>>H I
)>>I J
]>>J K
public?? 
async?? 
Task?? 
<?? 
IActionResult?? '
>??' (
UpdateEvent??) 4
(??4 5
[??5 6
FromBody??6 >
]??> ?
EventUpdateRequest??@ R
request??S Z
,??Z [
[??\ ]
	FromRoute??] f
]??f g
int??h k
???k l
id??m o
)??o p
{@@ 	
requestAA 
.AA 
IdAA 
=AA 
idAA 
;AA 
returnBB 
SuccessBB 
(BB 
awaitBB  
	_mediatorBB! *
.BB* +
SendBB+ /
(BB/ 0
requestBB0 7
)BB7 8
)BB8 9
;BB9 :
}CC 	
[MM 	
HttpGetMM	 
]MM 
[NN 	 
ProducesResponseTypeNN	 
(NN 
$numNN !
,NN! "
TypeNN# '
=NN( )
typeofNN* 0
(NN0 1
EventGetResponseNN1 A
)NNA B
)NNB C
]NNC D
[OO 	 
ProducesResponseTypeOO	 
(OO 
$numOO !
,OO! "
TypeOO# '
=OO( )
typeofOO* 0
(OO0 1
GenericResponseOO1 @
<OO@ A
stringOOA G
>OOG H
)OOH I
)OOI J
]OOJ K
[PP 	 
ProducesResponseTypePP	 
(PP 
$numPP !
,PP! "
TypePP# '
=PP( )
typeofPP* 0
(PP0 1
GenericResponsePP1 @
<PP@ A
stringPPA G
>PPG H
)PPH I
)PPI J
]PPJ K
[QQ 	
RouteQQ	 
(QQ 
$strQQ 
)QQ 
]QQ 
[RR 	
RouteRR	 
(RR 
$strRR 
)RR 
]RR 
publicSS 
asyncSS 
TaskSS 
<SS 
IActionResultSS '
>SS' (

GetHandlerSS) 3
(SS3 4
[SS4 5
	FromQuerySS5 >
]SS> ?
EventGetRequestSS@ O
requestSSP W
,SSW X
[SSY Z
	FromRouteSSZ c
]SSc d
intSSe h
?SSh i
idSSj l
)SSl m
{TT 	
requestUU 
.UU 
IdUU 
=UU 
idUU 
;UU 
returnVV 
SuccessWW 
(WW 
awaitWW 
	_mediatorWW #
.WW# $
SendWW$ (
(WW( )
requestWW) 0
)WW0 1
)WW1 2
;WW2 3
}XX 	
}\\ 
}]] ¥K
cC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.WebApi\Controllers\UserController.cs
	namespace		 	
Dach		
 
.		 
ElectionSystem		 
.		 
WebApi		 $
.		$ %
Controllers		% 0
{

 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
UserController 
:  !
ApiControllerBase" 3
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public 
UserController 
( 
	IMediator '
mediator( 0
)0 1
{ 	
	_mediator 
= 
mediator  
;  !
} 	
[ 	
HttpPut	 
] 
[ 	 
ProducesResponseType	 
( 
$num !
,! "
Type# '
=( )
typeof* 0
(0 1
GenericResponse1 @
<@ A
UserUpdateResponseA S
>S T
)T U
)U V
]V W
[ 	 
ProducesResponseType	 
( 
$num !
,! "
Type# '
=( )
typeof* 0
(0 1
GenericResponse1 @
<@ A
stringA G
>G H
)H I
)I J
]J K
[ 	 
ProducesResponseType	 
( 
$num !
,! "
Type# '
=( )
typeof* 0
(0 1
GenericResponse1 @
<@ A
stringA G
>G H
)H I
)I J
]J K
[   	
ServiceFilter  	 
(   
typeof   
(   
Utils   #
.  # $
Filters  $ +
.  + , 
ModelFilterAttribute  , @
)  @ A
)  A B
]  B C
public!! 
async!! 
Task!! 
<!! 
IActionResult!! '
>!!' (

UpdateUser!!) 3
(!!3 4
[!!4 5
FromBody!!5 =
]!!= >
UserUpdateRequest!!? P
request!!Q X
)!!X Y
=>!!Z \
Success!!] d
(!!d e
await!!e j
	_mediator!!k t
.!!t u
Send!!u y
(!!y z
request	!!z Å
)
!!Å Ç
)
!!Ç É
;
!!É Ñ
[&& 	
HttpGet&&	 
]&& 
['' 	 
ProducesResponseType''	 
('' 
$num'' !
,''! "
Type''# '
=''( )
typeof''* 0
(''0 1
GenericResponse''1 @
<''@ A
UserGetResponse''A P
>''P Q
)''Q R
)''R S
]''S T
[(( 	 
ProducesResponseType((	 
((( 
$num(( !
,((! "
Type((# '
=((( )
typeof((* 0
(((0 1
GenericResponse((1 @
<((@ A
string((A G
>((G H
)((H I
)((I J
]((J K
[)) 	 
ProducesResponseType))	 
()) 
$num)) !
,))! "
Type))# '
=))( )
typeof))* 0
())0 1
GenericResponse))1 @
<))@ A
string))A G
>))G H
)))H I
)))I J
]))J K
[** 	
Route**	 
(** 
$str** 
)** 
]** 
[++ 	
Route++	 
(++ 
$str++ 
)++ 
]++ 
[,, 	
ServiceFilter,,	 
(,, 
typeof,, 
(,, 
Utils,, #
.,,# $
Filters,,$ +
.,,+ , 
ModelFilterAttribute,,, @
),,@ A
),,A B
],,B C
public-- 
async-- 
Task-- 
<-- 
IActionResult-- '
>--' (

GetHandler--) 3
(--3 4
[--4 5
	FromQuery--5 >
]--> ?
UserGetRequest--@ N
request--O V
,--V W
[--X Y
	FromRoute--Y b
]--b c
int--d g
?--g h
id--i k
)--k l
{.. 	
if// 
(// 
id// 
!=// 
null// 
)// 
request00 
.00 
Id00 
=00 
id00 
;00  
return11 
Success11 
(11 
await11  
	_mediator11! *
.11* +
Send11+ /
(11/ 0
request110 7
)117 8
)118 9
;119 :
}22 	
[77 	
HttpPost77	 
]77 
[88 	 
ProducesResponseType88	 
(88 
$num88 !
,88! "
Type88# '
=88( )
typeof88* 0
(880 1
GenericResponse881 @
<88@ A
UserCreateResponse88A S
>88S T
)88T U
)88U V
]88V W
[99 	 
ProducesResponseType99	 
(99 
$num99 !
,99! "
Type99# '
=99( )
typeof99* 0
(990 1
GenericResponse991 @
<99@ A
string99A G
>99G H
)99H I
)99I J
]99J K
[:: 	 
ProducesResponseType::	 
(:: 
$num:: !
,::! "
Type::# '
=::( )
typeof::* 0
(::0 1
GenericResponse::1 @
<::@ A
string::A G
>::G H
)::H I
)::I J
]::J K
public;; 
async;; 
Task;; 
<;; 
IActionResult;; '
>;;' (

CreateUser;;) 3
(;;3 4
[;;4 5
FromBody;;5 =
];;= >
UserCreateRequest;;? P
request;;Q X
);;X Y
=><< 

Success<< 
(<< 
await<< 
	_mediator<< "
.<<" #
Send<<# '
(<<' (
request<<( /
)<</ 0
)<<0 1
;<<1 2
[BB 	
HttpPostBB	 
]BB 
[CC 	 
ProducesResponseTypeCC	 
(CC 
$numCC !
,CC! "
TypeCC# '
=CC( )
typeofCC* 0
(CC0 1
GenericResponseCC1 @
<CC@ A
UnitCCA E
>CCE F
)CCF G
)CCG H
]CCH I
[DD 	 
ProducesResponseTypeDD	 
(DD 
$numDD !
,DD! "
TypeDD# '
=DD( )
typeofDD* 0
(DD0 1
GenericResponseDD1 @
<DD@ A
stringDDA G
>DDG H
)DDH I
)DDI J
]DDJ K
[EE 	 
ProducesResponseTypeEE	 
(EE 
$numEE !
,EE! "
TypeEE# '
=EE( )
typeofEE* 0
(EE0 1
GenericResponseEE1 @
<EE@ A
stringEEA G
>EEG H
)EEH I
)EEI J
]EEJ K
[FF 	
ServiceFilterFF	 
(FF 
typeofFF 
(FF 
UtilsFF #
.FF# $
FiltersFF$ +
.FF+ , 
ModelFilterAttributeFF, @
)FF@ A
)FFA B
]FFB C
[GG 	
RouteGG	 
(GG 
$strGG 
)GG  
]GG  !
publicHH 
asyncHH 
TaskHH 
<HH 
IActionResultHH '
>HH' (
ChangePasswordHH) 7
(HH7 8
[HH8 9
FromBodyHH9 A
]HHA B!
ChangePasswordRequestHHC X
requestHHY `
)HH` a
=>II 

SuccessII 
(II 
awaitII 
	_mediatorII "
.II" #
SendII# '
(II' (
requestII( /
)II/ 0
)II0 1
;II1 2
[NN 	
HttpPostNN	 
]NN 
[OO 	 
ProducesResponseTypeOO	 
(OO 
$numOO !
,OO! "
TypeOO# '
=OO( )
typeofOO* 0
(OO0 1
GenericResponseOO1 @
<OO@ A
UnitOOA E
>OOE F
)OOF G
)OOG H
]OOH I
[PP 	 
ProducesResponseTypePP	 
(PP 
$numPP !
,PP! "
TypePP# '
=PP( )
typeofPP* 0
(PP0 1
GenericResponsePP1 @
<PP@ A
stringPPA G
>PPG H
)PPH I
)PPI J
]PPJ K
[QQ 	 
ProducesResponseTypeQQ	 
(QQ 
$numQQ !
,QQ! "
TypeQQ# '
=QQ( )
typeofQQ* 0
(QQ0 1
GenericResponseQQ1 @
<QQ@ A
stringQQA G
>QQG H
)QQH I
)QQI J
]QQJ K
[RR 	
ServiceFilterRR	 
(RR 
typeofRR 
(RR 
UtilsRR #
.RR# $
FiltersRR$ +
.RR+ , 
ModelFilterAttributeRR, @
)RR@ A
)RRA B
]RRB C
[SS 	
RouteSS	 
(SS 
$strSS 
)SS  
]SS  !
publicTT 
asyncTT 
TaskTT 
<TT 
IActionResultTT '
>TT' (
IncreaseEventsTT) 7
(TT7 8
[TT8 9
FromBodyTT9 A
]TTA B!
IncreaseEventsRequestTTC X
requestTTY `
)TT` a
=>UU 

SuccessUU 
(UU 
awaitUU 
	_mediatorUU "
.UU" #
SendUU# '
(UU' (
requestUU( /
)UU/ 0
)UU0 1
;UU1 2
}XX 
}YY ®B
cC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.WebApi\Controllers\VoteController.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
WebApi $
.$ %
Controllers% 0
{		 
[

 
Route

 

(


 
$str

 
)

 
]

 
[ 
ApiController 
] 
[ 
ServiceFilter 
( 
typeof 
(  
ModelFilterAttribute .
). /
)/ 0
]0 1
public 

class 
VoteController 
:  !
ApiControllerBase" 3
{ 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public 
VoteController 
( 
	IMediator '
mediator( 0
)0 1
=>2 4
	_mediator 
= 
mediator  
;  !
[ 	
Route	 
( 
$str 0
)0 1
]1 2
[ 	
HttpPost	 
] 
[   	 
ProducesResponseType  	 
(   
$num   !
,  ! "
Type  # '
=  ( )
typeof  * 0
(  0 1
VoteCreateResponse  1 C
)  C D
)  D E
]  E F
[!! 	 
ProducesResponseType!!	 
(!! 
$num!! !
,!!! "
Type!!# '
=!!( )
typeof!!* 0
(!!0 1
GenericResponse!!1 @
<!!@ A
string!!A G
>!!G H
)!!H I
)!!I J
]!!J K
["" 	 
ProducesResponseType""	 
("" 
$num"" !
,""! "
Type""# '
=""( )
typeof""* 0
(""0 1
GenericResponse""1 @
<""@ A
string""A G
>""G H
)""H I
)""I J
]""J K
public## 
async## 
Task## 
<## 
IActionResult## '
>##' (

CreateVote##) 3
(##3 4
[$$ 
FromBody$$ 
]$$ 
VoteCreateRequest$$ (
request$$) 0
,$$0 1
[%% 
	FromRoute%% 
]%% 
int%% 
idEvent%% #
,%%# $
[&& 
	FromRoute&& 
]&& 
int&& 
idUser&& "
)'' 
{(( 	
request)) 
.)) 
IdUser)) 
=)) 
idUser)) #
;))# $
request** 
.** 
IdEvent** 
=** 
idEvent** %
;**% &
return++ 
Success++ 
(++ 
await++  
	_mediator++! *
.++* +
Send+++ /
(++/ 0
request++0 7
)++7 8
)++8 9
;++9 :
},, 	
[44 	

HttpDelete44	 
]44 
[55 	
Route55	 
(55 
$str55 !
)55! "
]55" #
[66 	 
ProducesResponseType66	 
(66 
$num66 !
,66! "
Type66# '
=66( )
typeof66* 0
(660 1
VoteDeleteResponse661 C
)66C D
)66D E
]66E F
[77 	 
ProducesResponseType77	 
(77 
$num77 !
,77! "
Type77# '
=77( )
typeof77* 0
(770 1
GenericResponse771 @
<77@ A
string77A G
>77G H
)77H I
)77I J
]77J K
[88 	 
ProducesResponseType88	 
(88 
$num88 !
,88! "
Type88# '
=88( )
typeof88* 0
(880 1
GenericResponse881 @
<88@ A
string88A G
>88G H
)88H I
)88I J
]88J K
public99 
async99 
Task99 
<99 
IActionResult99 '
>99' (
DesactiveVote99) 6
(996 7
[:: 
	FromQuery:: 
]:: 
VoteDeleteRequest:: )
request::* 1
,::1 2
[;; 
	FromRoute;; 
];; 
int;; 
idEvent;; #
);;# $
{<< 	
request== 
.== 
IdEvent== 
=== 
idEvent== %
;==% &
return>> 
Success>> 
(>> 
await>>  
	_mediator>>! *
.>>* +
Send>>+ /
(>>/ 0
request>>0 7
)>>7 8
)>>8 9
;>>9 :
}?? 	
[HH 	
HttpPutHH	 
]HH 
[II 	
RouteII	 
(II 
$strII :
)II: ;
]II; <
[JJ 	 
ProducesResponseTypeJJ	 
(JJ 
$numJJ !
,JJ! "
TypeJJ# '
=JJ( )
typeofJJ* 0
(JJ0 1
VoteUpdateResponseJJ1 C
)JJC D
)JJD E
]JJE F
[KK 	 
ProducesResponseTypeKK	 
(KK 
$numKK !
,KK! "
TypeKK# '
=KK( )
typeofKK* 0
(KK0 1
GenericResponseKK1 @
<KK@ A
stringKKA G
>KKG H
)KKH I
)KKI J
]KKJ K
[LL 	 
ProducesResponseTypeLL	 
(LL 
$numLL !
,LL! "
TypeLL# '
=LL( )
typeofLL* 0
(LL0 1
GenericResponseLL1 @
<LL@ A
stringLLA G
>LLG H
)LLH I
)LLI J
]LLJ K
publicMM 
asyncMM 
TaskMM 
<MM 
IActionResultMM '
>MM' (

UpdateVoteMM) 3
(MM3 4
[NN 
FromBodyNN 
]NN 
VoteUpdateRequestNN (
requestNN) 0
,NN0 1
[OO 
	FromRouteOO 
]OO 
intOO 
idEventOO #
,OO# $
[PP 
	FromRoutePP 
]PP 
intPP 
idCandidatePP '
)PP' (
{QQ 	
requestRR 
.RR 
IdEventRR 
=RR 
idEventRR %
;RR% &
requestSS 
.SS 
IdCandidateSS 
=SS  !
idCandidateSS" -
;SS- .
returnTT 
SuccessTT 
(TT 
awaitTT  
	_mediatorTT! *
.TT* +
SendTT+ /
(TT/ 0
requestTT0 7
)TT7 8
)TT8 9
;TT9 :
}UU 	
[__ 	
HttpGet__	 
]__ 
[`` 	 
ProducesResponseType``	 
(`` 
$num`` !
,``! "
Type``# '
=``( )
typeof``* 0
(``0 1
VoteGetResponse``1 @
)``@ A
)``A B
]``B C
[aa 	 
ProducesResponseTypeaa	 
(aa 
$numaa !
,aa! "
Typeaa# '
=aa( )
typeofaa* 0
(aa0 1
GenericResponseaa1 @
<aa@ A
stringaaA G
>aaG H
)aaH I
)aaI J
]aaJ K
[bb 	 
ProducesResponseTypebb	 
(bb 
$numbb !
,bb! "
Typebb# '
=bb( )
typeofbb* 0
(bb0 1
GenericResponsebb1 @
<bb@ A
stringbbA G
>bbG H
)bbH I
)bbI J
]bbJ K
[cc 	
Routecc	 
(cc 
$strcc !
)cc! "
]cc" #
[dd 	
Routedd	 
(dd 
$strdd 
)dd 
]dd 
[ee 	
Routeee	 
(ee 
$stree 
)ee  
]ee  !
publicff 
asyncff 
Taskff 
<ff 
IActionResultff '
>ff' (

GetHandlerff) 3
(ff3 4
[gg 
	FromQuerygg 
]gg 
VoteGetRequestgg &
requestgg' .
,gg. /
[hh 
	FromRoutehh 
]hh 
inthh 
idEventhh #
)hh# $
{ii 	
requestjj 
.jj 
IdEventjj 
=jj 
idEventjj %
;jj% &
returnkk 
Successkk 
(kk 
awaitkk  
	_mediatorkk! *
.kk* +
Sendkk+ /
(kk/ 0
requestkk0 7
)kk7 8
)kk8 9
;kk9 :
}ll 	
}pp 
}qq Ì
PC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.WebApi\Program.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
WebApi $
{ 
public		 

static		 
class		 
Program		 
{

 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5

webBuilder 
. 
ConfigureLogging /
(/ 0
(0 1
ctx1 4
,4 5
builder6 =
)= >
=>? A
{ 
builder 
.  
AddFile  '
(' (
$"( *
{* +
	Directory+ 4
.4 5
GetCurrentDirectory5 H
(H I
)I J
}J K
\\Logs\\Log.txtK Z
"Z [
,[ \
outputTemplate] k
:k l
$str	m √
)
√ ƒ
;
ƒ ≈
} 
) 
; 
} 
) 
; 
} 
} ô#
PC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.WebApi\Startup.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
WebApi $
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public   
void   
ConfigureServices   %
(  % &
IServiceCollection  & 8
services  9 A
)  A B
{!! 	
services"" 
."" 
AddDbContext"" !
<""! "
WebApiDbContext""" 1
>""1 2
(""2 3
options""3 :
=>""; =
options""> E
.""E F
UseSqlServer""F R
(""R S
Environment""S ^
.""^ _"
GetEnvironmentVariable""_ u
(""u v
$str	""v Ü
)
""Ü á
)
""á à
)
""à â
;
""â ä
services## 
.## 
AddRepositorys## #
(### $
)##$ %
;##% &
services$$ 
.$$ 
AddServices$$  
($$  !
)$$! "
;$$" #
services%% 
.%% 
ConfigureController%% (
(%%( )
)%%) *
;%%* +
services'' 
.'' 
AddSwaggerGen'' "
(''" #
c''# $
=>''% '
{(( 
c)) 
.)) 

SwaggerDoc)) 
()) 
$str)) "
,))" #
new))$ '
OpenApiInfo))( 3
{))4 5
Title))6 ;
=))< =
$str))> U
,))U V
Version))W ^
=))_ `
$str))a e
}))f g
)))g h
;))h i
c** 
.** 
IncludeXmlComments** %
(**% &
$str**& :
)**: ;
;**; <
c++ 
.++ 
IncludeXmlComments++ %
(++% &
$str++& @
)++@ A
;++A B
}// 
)// 
;// 
services00 
.00 $
ConfigureSwaggerServices00 -
(00- .
)00. /
;00/ 0
services11 
.11 

AddMediatR11 
(11  
typeof11  &
(11& '
AuthHandler11' 2
)112 3
)113 4
;114 5
services22 
.22 
AddAutoMapper22 "
(22" #
typeof22# )
(22) *
CustomMapperDto22* 9
)229 :
)22: ;
;22; <
services33 
.33 
	AddScoped33 
<33  
ModelFilterAttribute33 3
>333 4
(334 5
)335 6
;336 7
}44 	
public55 
void55 
	Configure55 
(55 
IApplicationBuilder55 1
app552 5
,555 6
IWebHostEnvironment557 J
env55K N
)55N O
{66 	
if99 
(99 
env99 
.99 
IsDevelopment99 !
(99! "
)99" #
)99# $
app:: 
.:: %
UseDeveloperExceptionPage:: -
(::- .
)::. /
;::/ 0
app;; 
.;; 

UseSwagger;; 
(;; 
);; 
;;; 
app<< 
.<< 
UseSwaggerUI<< 
(<< 
c<< 
=><< !
c<<" #
.<<# $
SwaggerEndpoint<<$ 3
(<<3 4
$str<<4 N
,<<N O
$str<<P j
)<<j k
)<<k l
;<<l m
app== 
.== 
UseHttpsRedirection== $
(==$ %
)==% &
;==& '
app>> 
.>> 
SetCustomMiddleWare>> #
(>># $
)>>$ %
;>>% &
appAA 
.AA 

UseRoutingAA 
(AA 
)AA 
;AA 
appDD 
.DD 
UseEndpointsDD 
(DD 
	endpointsDD &
=>DD' )
{EE 
	endpointsFF 
.FF 
MapControllersFF (
(FF( )
)FF) *
;FF* +
}HH 
)HH 
;HH 
}II 	
}JJ 
}KK É
ÖC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.WebApi\obj\Debug\net5.0\.NETCoreApp,Version=v5.0.AssemblyAttributes.cs
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
]| }Ù
ÅC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.WebApi\obj\Debug\net5.0\Dach.ElectionSystem.WebApi.AssemblyInfo.cs
[ 
assembly 	
:	 

	Microsoft 
. 

Extensions 
.  
Configuration  -
.- .
UserSecrets. 9
.9 :"
UserSecretsIdAttribute: P
(P Q
$strQ w
)w x
]x y
[ 
assembly 	
:	 

System 
. 

Reflection 
. $
AssemblyCompanyAttribute 5
(5 6
$str6 R
)R S
]S T
[ 
assembly 	
:	 

System 
. 

Reflection 
. *
AssemblyConfigurationAttribute ;
(; <
$str< C
)C D
]D E
[ 
assembly 	
:	 

System 
. 

Reflection 
. (
AssemblyFileVersionAttribute 9
(9 :
$str: C
)C D
]D E
[ 
assembly 	
:	 

System 
. 

Reflection 
. 1
%AssemblyInformationalVersionAttribute B
(B C
$strC J
)J K
]K L
[ 
assembly 	
:	 

System 
. 

Reflection 
. $
AssemblyProductAttribute 5
(5 6
$str6 R
)R S
]S T
[ 
assembly 	
:	 

System 
. 

Reflection 
. "
AssemblyTitleAttribute 3
(3 4
$str4 P
)P Q
]Q R
[ 
assembly 	
:	 

System 
. 

Reflection 
. $
AssemblyVersionAttribute 5
(5 6
$str6 ?
)? @
]@ AÓ
îC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.WebApi\obj\Debug\net5.0\Dach.ElectionSystem.WebApi.MvcApplicationPartsAssemblyInfo.cs
[ 
assembly 	
:	 

	Microsoft 
. 

AspNetCore 
.  
Mvc  #
.# $
ApplicationParts$ 4
.4 5$
ApplicationPartAttribute5 M
(M N
$strN q
)q r
]r s
[ 
assembly 	
:	 

	Microsoft 
. 

AspNetCore 
.  
Mvc  #
.# $
ApplicationParts$ 4
.4 5$
ApplicationPartAttribute5 M
(M N
$strN j
)j k
]k l
[ 
assembly 	
:	 

	Microsoft 
. 

AspNetCore 
.  
Mvc  #
.# $
ApplicationParts$ 4
.4 5$
ApplicationPartAttribute5 M
(M N
$strN n
)n o
]o p
[ 
assembly 	
:	 

	Microsoft 
. 

AspNetCore 
.  
Mvc  #
.# $
ApplicationParts$ 4
.4 5$
ApplicationPartAttribute5 M
(M N
$strN l
)l m
]m n
[ 
assembly 	
:	 

	Microsoft 
. 

AspNetCore 
.  
Mvc  #
.# $
ApplicationParts$ 4
.4 5$
ApplicationPartAttribute5 M
(M N
$strN i
)i j
]j k
[ 
assembly 	
:	 

	Microsoft 
. 

AspNetCore 
.  
Mvc  #
.# $
ApplicationParts$ 4
.4 5$
ApplicationPartAttribute5 M
(M N
$strN q
)q r
]r s
[ 
assembly 	
:	 

	Microsoft 
. 

AspNetCore 
.  
Mvc  #
.# $
ApplicationParts$ 4
.4 5$
ApplicationPartAttribute5 M
(M N
$strN q
)q r
]r s