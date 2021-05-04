∏
fC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\DBContext\WebApiDbContext.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )
	DBContext) 2
{ 
public 

class 
WebApiDbContext  
:! "
	DbContext# ,
{ 
public		 
WebApiDbContext		 !
(		! "
DbContextOptions		" 2
<		2 3
WebApiDbContext		3 B
>		B C
options		D K
)		K L
:		M N
base		O S
(		S T
options		T [
)		[ \
{

 	
} 	
public 
DbSet 
< 
User 
> 
User 
{  !
get" %
;% &
set' *
;* +
}, -
public 
DbSet 
< 
Event 
> 
Event !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
DbSet 
< 
	Candidate 
> 
	Candidate  )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
DbSet 
< 
Vote 
> 
Vote 
{  !
get" %
;% &
set' *
;* +
}, -
public 
DbSet 
< 
EventAdministrator '
>' (
EventAdministrator) ;
{< =
get> A
;A B
setC F
;F G
}H I
public 
DbSet 
< 
EventNumber  
>  !
EventNumber" -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
} 
} ¢
oC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\Implementation\CandidateRepository.cs
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
 

Repository

 (
.

( )
Implementation

) 7
{ 
public 

class 
CandidateRepository $
:% &
GenericRepository' 8
<8 9
	Candidate9 B
>B C
,C D 
ICandidateRepositoryE Y
{ 
public 
CandidateRepository "
(" #
IUnitOfWork# .

unitOfWork/ 9
)9 :
:; <
base= A
(A B

unitOfWorkB L
)L M
{ 	
} 	
} 
} œ
xC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\Implementation\EventAdministratorRepository.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )
Implementation) 7
{ 
public 

class (
EventAdministratorRepository -
:. /
GenericRepository0 A
<A B
EventAdministratorB T
>T U
,U V)
IEventAdministratorRepositoryW t
{ 
public		 (
EventAdministratorRepository		 +
(		+ ,
IUnitOfWork		, 7

unitOfWork		8 B
)		B C
:		D E
base		F J
(		J K

unitOfWork		K U
)		U V
{		V W
}		W X
} 
} œ
kC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\Implementation\EventRepository.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )
Implementation) 7
{ 
public 

class 
EventRepository  
:! "
GenericRepository# 4
<4 5
Event5 :
>: ;
,; <
IEventRepository= M
{ 
public 
EventRepository 
( 
IUnitOfWork *

unitOfWork+ 5
)5 6
:7 8
base9 =
(= >

unitOfWork> H
)H I
{I J
}J K
public 
async 
Task 
< 
IEnumerable %
<% &
Event& +
>+ ,
>, -+
GetEventsWithAdministratorAsync. M
(M N

ExpressionN X
<X Y
FuncY ]
<] ^
Event^ c
,c d
boole i
>i j
>j k
whereConditionl z
={ |
null	} Å
,
Å Ç
Func
É á
<
á à

IQueryable
à í
<
í ì
Event
ì ò
>
ò ô
,
ô ö
IOrderedQueryable	 
< 
Event  
>  !
>! "
orderBy# *
=+ ,
null- 1
,1 2
string	 
includeProperties !
=" #
$str$ &
)) *
{ 	
var 
query 
= 
await 
this "
." #
GetQueryAsync# 0
(0 1
whereCondition1 ?
,? @
orderByA H
,H I
includePropertiesJ [
)[ \
;\ ]
return 
await 
query 
. 
Include &
(& '
e' (
=>( *
e* +
.+ ,"
ListEventAdministrator, B
)B C
.C D
ToListAsyncD O
(O P
)P Q
;Q R
} 	
} 
} Ûl
mC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\Implementation\GenericRepository.cs
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
 

Repository

 (
.

( )
Implementation

) 7
{ 
public 

class 
GenericRepository "
<" #
T# $
>$ %
:& '
IGenericRepository( :
<: ;
T; <
>< =
where> C
TD E
:F G
classH M
{ 
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
public 
GenericRepository  
(  !
IUnitOfWork! ,

unitOfWork- 7
)7 8
{ 	
_unitOfWork 
= 

unitOfWork $
;$ %
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
T& '
>' (
>( )
GetAsync* 2
(2 3
)3 4
{ 	
return 
await 
_unitOfWork $
.$ %
Context% ,
., -
Set- 0
<0 1
T1 2
>2 3
(3 4
)4 5
.5 6
ToListAsync6 A
(A B
)B C
;C D
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
T& '
>' (
>( )
GetAsync* 2
(2 3

Expression3 =
<= >
Func> B
<B C
TC D
,D E
boolF J
>J K
>K L
whereConditionM [
,[ \
Func" &
<& '

IQueryable' 1
<1 2
T2 3
>3 4
,4 5
IOrderedQueryable6 G
<G H
TH I
>I J
>J K
orderByL S
=T U
nullV Z
,Z [
string" (
includeProperties) :
=; <
$str= ?
)? @
{ 	

IQueryable 
< 
T 
> 
query 
=  !
_unitOfWork" -
.- .
Context. 5
.5 6
Set6 9
<9 :
T: ;
>; <
(< =
)= >
;> ?
if   
(   
whereCondition   
!=   !
null  " &
)  & '
{!! 
query"" 
="" 
query"" 
."" 
Where"" #
(""# $
whereCondition""$ 2
)""2 3
;""3 4
}## 
foreach$$ 
($$ 
var$$ 
includeProperty$$ (
in$$) +
includeProperties$$, =
.$$= >
Split$$> C
(%%	 

new%%
 
char%% 
[%% 
]%% 
{%% 
$char%% 
}%% 
,%% 
StringSplitOptions%% 0
.%%0 1
RemoveEmptyEntries%%1 C
)%%C D
)%%D E
{&& 
query'' 
='' 
query'' 
.'' 
Include'' %
(''% &
includeProperty''& 5
)''5 6
;''6 7
}(( 
if** 
(** 
orderBy** 
!=** 
null** 
)**  
{++ 
return,, 
await,, 
orderBy,, $
(,,$ %
query,,% *
),,* +
.,,+ ,
ToListAsync,,, 7
(,,7 8
),,8 9
;,,9 :
}-- 
else.. 
{// 
return00 
await00 
query00 "
.00" #
ToListAsync00# .
(00. /
)00/ 0
;000 1
}11 
}22 	
public44 
async44 
Task44 
<44 

IQueryable44 $
<44$ %
T44% &
>44& '
>44' (
GetQueryAsync44) 6
(446 7

Expression447 A
<44A B
Func44B F
<44F G
T44G H
,44H I
bool44J N
>44N O
>44O P
whereCondition44Q _
=44` a
null44b f
,44f g
Func55" &
<55& '

IQueryable55' 1
<551 2
T552 3
>553 4
,554 5
IOrderedQueryable556 G
<55G H
T55H I
>55I J
>55J K
orderBy55L S
=55T U
null55V Z
,55Z [
string66" (
includeProperties66) :
=66; <
$str66= ?
)66? @
{77 	

IQueryable88 
<88 
T88 
>88 
query88 
=88  !
_unitOfWork88" -
.88- .
Context88. 5
.885 6
Set886 9
<889 :
T88: ;
>88; <
(88< =
)88= >
;88> ?
if:: 
(:: 
whereCondition:: 
!=:: !
null::" &
)::& '
{;; 
query<< 
=<< 
query<< 
.<< 
Where<< #
(<<# $
whereCondition<<$ 2
)<<2 3
;<<3 4
}== 
foreach>> 
(>> 
var>> 
includeProperty>> (
in>>) +
includeProperties>>, =
.>>= >
Split>>> C
(??	 

new??
 
char?? 
[?? 
]?? 
{?? 
$char?? 
}?? 
,?? 
StringSplitOptions?? 0
.??0 1
RemoveEmptyEntries??1 C
)??C D
)??D E
{@@ 
queryAA 
=AA 
queryAA 
.AA 
IncludeAA %
(AA% &
includePropertyAA& 5
)AA5 6
;AA6 7
}BB 
ifDD 
(DD 
orderByDD 
!=DD 
nullDD 
)DD  
{EE 
_FF 
=FF 
orderByFF 
(FF 
queryFF !
)FF! "
;FF" #
}GG 
returnHH 
awaitHH 
TaskHH 
.HH 
RunHH !
<HH! "

IQueryableHH" ,
<HH, -
THH- .
>HH. /
>HH/ 0
(HH0 1
(HH1 2
)HH2 3
=>HH4 6
queryHH7 <
)HH< =
;HH= >
}II 	
publicKK 
asyncKK 
TaskKK 
<KK 
boolKK 
>KK 
CreateAsyncKK  +
(KK+ ,
TKK, -
entityKK. 4
)KK4 5
{LL 	
boolNN 
createdNN 
=NN 
falseNN  
;NN  !
varPP 
savePP 
=PP 
awaitPP 
_unitOfWorkPP (
.PP( )
ContextPP) 0
.PP0 1
SetPP1 4
<PP4 5
TPP5 6
>PP6 7
(PP7 8
)PP8 9
.PP9 :
AddAsyncPP: B
(PPB C
entityPPC I
)PPI J
;PPJ K
ifRR 
(RR 
saveRR 
!=RR 
nullRR 
)RR 
createdSS 
=SS 
trueSS 
;SS 
_unitOfWorkTT 
.TT 
ContextTT 
.TT  
SaveChangesTT  +
(TT+ ,
)TT, -
;TT- .
returnVV 
createdVV 
;VV 
}WW 	
publicYY 
asyncYY 
TaskYY 
<YY 
boolYY 
>YY 
UpdateYY  &
(YY& '
TYY' (
entityYY) /
)YY/ 0
{ZZ 	
bool\\ 
update\\ 
=\\ 
false\\ 
;\\  
var^^ 
save^^ 
=^^ 
_unitOfWork^^ "
.^^" #
Context^^# *
.^^* +
Set^^+ .
<^^. /
T^^/ 0
>^^0 1
(^^1 2
)^^2 3
.^^3 4
Update^^4 :
(^^: ;
entity^^; A
)^^A B
;^^B C
if`` 
(`` 
save`` 
!=`` 
null`` 
)`` 
updateaa 
=aa 
trueaa 
;aa 
_unitOfWorkbb 
.bb 
Contextbb 
.bb  
SaveChangesbb  +
(bb+ ,
)bb, -
;bb- .
returncc 
awaitcc 
Taskcc 
.cc 
Runcc !
<cc! "
boolcc" &
>cc& '
(cc' (
(cc( )
)cc) *
=>cc+ -
updatecc. 4
)cc4 5
;cc5 6
}dd 	
publicff 
asyncff 
Taskff 
<ff 
boolff 
>ff 
DeleteByIdAsyncff  /
(ff/ 0
intff0 3
Idff4 6
)ff6 7
{gg 	
boolhh 
removehh 
=hh 
falsehh 
;hh  
varii 
	getEntityii 
=ii 
awaitii !
thisii" &
.ii& '
GetByIdAsyncii' 3
(ii3 4
Idii4 6
)ii6 7
;ii7 8
varkk 
savekk 
=kk 
_unitOfWorkkk &
.kk& '
Contextkk' .
.kk. /
Setkk/ 2
<kk2 3
Tkk3 4
>kk4 5
(kk5 6
)kk6 7
.kk7 8
Removekk8 >
(kk> ?
	getEntitykk? H
)kkH I
;kkI J
ifmm 
(mm 
savemm 
!=mm 
nullmm  
)mm  !
removenn 
=nn 
truenn !
;nn! "
_unitOfWorkoo 
.oo 
Contextoo #
.oo# $
SaveChangesoo$ /
(oo/ 0
)oo0 1
;oo1 2
returnqq 
removeqq 
;qq 
}rr 	
publictt 
asynctt 
Tasktt 
<tt 
Ttt 
>tt 
GetByIdAsynctt )
(tt) *
inttt* -
Idtt. 0
)tt0 1
{uu 	
returnvv 
awaitvv 
_unitOfWorkvv $
.vv$ %
Contextvv% ,
.vv, -
Setvv- 0
<vv0 1
Tvv1 2
>vv2 3
(vv3 4
)vv4 5
.vv5 6
	FindAsyncvv6 ?
(vv? @
Idvv@ B
)vvB C
;vvC D
}ww 	
publicyy 
asyncyy 
Taskyy 
<yy 
IEnumerableyy %
<yy% &
Tyy& '
>yy' (
>yy( )
GetAsyncIncludeyy* 9
(yy9 :

Expressionyy: D
<yyD E
FuncyyE I
<yyI J
TyyJ K
,yyK L
boolyyM Q
>yyQ R
>yyR S
whereConditionyyT b
=yyc d
nullyye i
,yyi j
Funcyyk o
<yyo p

IQueryableyyp z
<yyz {
Tyy{ |
>yy| }
,yy} ~
IOrderedQueryable	yy ê
<
yyê ë
T
yyë í
>
yyí ì
>
yyì î
orderBy
yyï ú
=
yyù û
null
yyü £
,
yy£ §

Expressionzz 
<zz 
Funczz 
<zz 
Tzz 
,zz 
stringzz !
>zz! "
>zz" #
includePropertieszz$ 5
=zz6 7
nullzz8 <
)zz< =
{{{ 	

IQueryable~~ 
<~~ 
T~~ 
>~~ 
query~~ 
=~~  !
_unitOfWork~~" -
.~~- .
Context~~. 5
.~~5 6
Set~~6 9
<~~9 :
T~~: ;
>~~; <
(~~< =
)~~= >
;~~> ?
if
ÄÄ 
(
ÄÄ 
whereCondition
ÄÄ 
!=
ÄÄ !
null
ÄÄ" &
)
ÄÄ& '
{
ÅÅ 
query
ÇÇ 
=
ÇÇ 
query
ÇÇ 
.
ÇÇ 
Where
ÇÇ #
(
ÇÇ# $
whereCondition
ÇÇ$ 2
)
ÇÇ2 3
;
ÇÇ3 4
}
ÉÉ 
if
ÜÜ 
(
ÜÜ 
includeProperties
ÜÜ !
!=
ÜÜ" $
null
ÜÜ% )
)
ÜÜ) *
{
áá 
var
àà 
	propertys
àà 
=
àà 
includeProperties
àà  1
.
àà1 2
Body
àà2 6
.
àà6 7
ToString
àà7 ?
(
àà? @
)
àà@ A
.
ààA B
Replace
ààB I
(
ààI J
$str
ààJ N
,
ààN O
$str
ààP R
)
ààR S
.
ààS T
Replace
ààT [
(
àà[ \
$str
àà\ `
,
àà` a
$str
ààb d
)
ààd e
;
ààe f
foreach
ââ 
(
ââ 
var
ââ 
includeProperty
ââ ,
in
ââ- /
	propertys
ââ0 9
.
ââ9 :
Split
ââ: ?
(
ää 
new
ää 
char
ää 
[
ää 
]
ää 
{
ää 
$char
ää "
}
ää# $
,
ää$ % 
StringSplitOptions
ää& 8
.
ää8 9 
RemoveEmptyEntries
ää9 K
)
ääK L
)
ääL M
query
ãã 
=
ãã 
query
ãã !
.
ãã! "
Include
ãã" )
(
ãã) *
includeProperty
ãã* 9
)
ãã9 :
;
ãã: ;
}
åå 
if
éé 
(
éé 
orderBy
éé 
!=
éé 
null
éé 
)
éé  
{
èè 
return
êê 
await
êê 
orderBy
êê $
(
êê$ %
query
êê% *
)
êê* +
.
êê+ ,
ToListAsync
êê, 7
(
êê7 8
)
êê8 9
;
êê9 :
}
ëë 
else
íí 
{
ìì 
return
îî 
await
îî 
query
îî "
.
îî" #
ToListAsync
îî# .
(
îî. /
)
îî/ 0
;
îî0 1
}
ïï 
}
ññ 	
}
óó 
}òò ó&
jC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\Implementation\UserRepository.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )
Implementation) 7
{ 
public 

class 
UserRepository 
:  !
GenericRepository" 3
<3 4
User4 8
>8 9
,9 :
IUserRepository; J
{ 
private 
readonly 
IUnitOfWork $

unitOfWork% /
;/ 0
public 
UserRepository 
( 
IUnitOfWork )

unitOfWork* 4
)4 5
:6 7
base8 <
(< =

unitOfWork= G
)G H
{ 	
this 
. 

unitOfWork 
= 

unitOfWork (
;( )
} 	
public 
async 
Task 
< 
User 
> /
#GetUserByUsernameOrEmailAndPassword  C
(C D
stringD J
usernameK S
,S T
stringU [
password\ d
)d e
{ 	
var 
user 
= 

unitOfWork "
." #
Context# *
.* +
User+ /
./ 0
FirstOrDefault0 >
(> ?
user? C
=>D F
(G H
userH L
.L M
UserNameM U
==V X
usernameY a
||b d
usere i
.i j
Emailj o
==p r
usernames {
){ |
&&= ?
user@ D
.D E
PasswordE M
==N P
passwordQ Y
)Y Z
;Z [
return 
await 
Task 
. 
Run !
(! "
(" #
)# $
=>$ &
user& *
)* +
;+ ,
} 	
public 
async 
Task 
< 
User 
> %
GetUserByUsernameAndEmail  9
(9 :
string: @
usernameA I
,I J
stringK Q
emailR W
)W X
{ 	
var 
user 
= 

unitOfWork !
.! "
Context" )
.) *
User* .
.. /
FirstOrDefault/ =
(= >
user> B
=>C E
(F G
userG K
.K L
UserNameL T
==U W
usernameX `
||a c
userd h
.h i
Emaili n
==o q
emailr w
)w x
)x y
;y z
return 
await 
Task 
. 
Run !
(! "
(" #
)# $
=>% '
user( ,
), -
;- .
}   	
public!! 
async!! 
Task!! 
<!! 
User!! 
>!! $
GetUserByUsernameByEmail!!  8
(!!8 9
string!!9 ?
email!!@ E
)!!E F
{"" 	
var## 
user## 
=## 

unitOfWork## !
.##! "
Context##" )
.##) *
User##* .
.##. /
Include##/ 6
(##6 7
u##7 8
=>##8 :
u##: ;
.##; <"
ListEventAdministrator##< R
)##R S
.##S T
FirstOrDefault$$ 
($$ 
user$$ 
=>$$  "
user$$# '
.$$' (
Email$$( -
==$$. 0
email$$1 6
)$$6 7
;$$7 8
return%% 
await%% 
Task%% 
.%% 
Run%% !
(%%! "
(%%" #
)%%# $
=>%%% '
user%%( ,
)%%, -
;%%- .
}&& 	
public'' 
async'' 
Task'' 
<'' 
User'' 
>'' '
GetUserByUsernameByUsername''  ;
(''; <
string''< B
username''C K
)''K L
{(( 	
var)) 
user)) 
=)) 

unitOfWork)) !
.))! "
Context))" )
.))) *
User))* .
.)). /
FirstOrDefault))/ =
())= >
user))> B
=>))C E
())F G
user))G K
.))K L
UserName))L T
==))U W
username))X `
)))` a
)))a b
;))b c
return** 
await** 
Task** 
.** 
Run** !
(**! "
(**" #
)**# $
=>**% '
user**( ,
)**, -
;**- .
}++ 	
},, 
}-- â
jC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\Implementation\VoteRepository.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )
Implementation) 7
{ 
public 

class 
VoteRepository 
:  !
GenericRepository" 3
<3 4
Vote4 8
>8 9
,9 :
IVoteRepository; J
{ 
public		 
VoteRepository		 
(		 
IUnitOfWork		 )

unitOfWork		* 4
)		4 5
:		6 7
base		8 <
(		< =

unitOfWork		= G
)		G H
{

 	
} 	
} 
} ˜
lC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\Interfaces\ICandidateRepository.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )

Interfaces) 3
{		 
public

 

	interface

  
ICandidateRepository

 )
:

* +
IGenericRepository

, >
<

> ?
	Candidate

? H
>

H I
{ 
} 
} í
uC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\Interfaces\IEventAdministratorRepository.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )

Interfaces) 3
{		 
public

 

	interface

 )
IEventAdministratorRepository

 2
:

3 4
IGenericRepository

5 G
<

G H
EventAdministrator

H Z
>

Z [
{ 
} 
} ü

hC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\Interfaces\IEventRepository.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )

Interfaces) 3
{		 
public

 

	interface

 
IEventRepository

 %
:

& '
IGenericRepository

( :
<

: ;
Event

; @
>

@ A
{ 
Task 
< 	
IEnumerable	 
< 
Event 
> 
> +
GetEventsWithAdministratorAsync <
(< =

Expression> H
<H I
FuncI M
<M N
EventN S
,S T
boolU Y
>Y Z
>Z [
whereCondition\ j
=k l
nullm q
,q r
Funcs w
<w x

IQueryable	x Ç
<
Ç É
Event
É à
>
à â
,
â ä
IOrderedQueryable< M
<M N
EventN S
>S T
>T U
orderByV ]
=^ _
null` d
,d e
string8 >
includeProperties? P
=Q R
$strS U
)U V
;V W
} 
} ÿ
jC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\Interfaces\IGenericRepository.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )

Interfaces) 3
{ 
public		 

	interface		 
IGenericRepository		 '
<		' (
T		( )
>		) *
where		+ 0
T		1 2
:		3 4
class		5 :
{

 
Task 
< 
T 
> 
GetByIdAsync 
( 
int  
Id! #
)# $
;$ %
Task 
< 
IEnumerable 
< 
T 
> 
> 
GetAsync %
(% &
)& '
;' (
Task 
< 
IEnumerable 
< 
T 
> 
> 
GetAsync %
(% &

Expression& 0
<0 1
Func1 5
<5 6
T6 7
,7 8
bool9 =
>= >
>> ?
whereCondition@ N
,N O
Func 
<  

IQueryable  *
<* +
T+ ,
>, -
,- .
IOrderedQueryable/ @
<@ A
TA B
>B C
>C D
orderByE L
=M N
nullO S
,S T
string !
includeProperties" 3
=4 5
$str6 8
)8 9
;9 :
Task 
< 
IEnumerable 
< 
T 
> 
> 
GetAsyncInclude ,
(, -

Expression- 7
<7 8
Func8 <
<< =
T= >
,> ?
bool@ D
>D E
>E F
whereConditionG U
=V W
nullX \
,\ ]
Func  
<  !

IQueryable! +
<+ ,
T, -
>- .
,. /
IOrderedQueryable0 A
<A B
TB C
>C D
>D E
orderByF M
=N O
nullP T
,T U

Expression &
<& '
Func' +
<+ ,
T, -
,- .
string/ 5
>5 6
>6 7
includeProperties8 I
=K L
nullM Q
)Q R
;R S
Task 
< 
bool 
> 
CreateAsync 
( 
T  
entity! '
)' (
;( )
Task 
< 
bool 
> 
DeleteByIdAsync "
(" #
int# &
Id' )
)) *
;* +
Task 
< 
bool 
> 
Update 
( 
T 
entity "
)" #
;# $
Task 
< 

IQueryable 
< 
T 
> 
> 
GetQueryAsync )
() *

Expression* 4
<4 5
Func5 9
<9 :
T: ;
,; <
bool= A
>A B
>B C
whereConditionD R
=S T
nullU Y
,Y Z
Func" &
<& '

IQueryable' 1
<1 2
T2 3
>3 4
,4 5
IOrderedQueryable6 G
<G H
TH I
>I J
>J K
orderByL S
=T U
nullV Z
,Z [
string" (
includeProperties) :
=; <
$str= ?
)? @
;@ A
} 
} ﬂ

gC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\Interfaces\IUserRepository.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )

Interfaces) 3
{ 
public 

	interface 
IUserRepository $
:% &
IGenericRepository' 9
<9 :
User: >
>> ?
{ 
Task 
< 
User 
> /
#GetUserByUsernameOrEmailAndPassword 6
(6 7
string7 =
username> F
,F G
stringH N
passwordO W
)W X
;X Y
Task		 
<		 
User		 
>		 %
GetUserByUsernameAndEmail		 ,
(		, -
string		- 3
username		4 <
,		< =
string		> D
email		E J
)		J K
;		K L
Task

 
<

 
User

 
>

 $
GetUserByUsernameByEmail

 +
(

+ ,
string

, 2
email

3 8
)

8 9
;

9 :
Task 
< 
User 
> '
GetUserByUsernameByUsername .
(. /
string/ 5
username6 >
)> ?
;? @
} 
} Ë
gC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\Interfaces\IVoteRepository.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )

Interfaces) 3
{ 
public 

	interface 
IVoteRepository $
:% &
IGenericRepository( :
<: ;
Vote; ?
>? @
{ 
} 
}		 ¨
jC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\Intrastructure\InitRepository.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )
Intrastructure) 7
{ 
public 

static 
class 
InitRepository &
{ 
public		 
static		 
void		 
AddRepositorys		 )
(		) *
this		* .
IServiceCollection		/ A
services		B J
)		J K
{		L M
services

 
.

 
AddTransient

 !
<

! "
IUserRepository

" 1
,

1 2
UserRepository

3 A
>

A B
(

B C
)

C D
;

D E
services 
. 
AddTransient !
<! "
IEventRepository" 2
,2 3
EventRepository4 C
>C D
(D E
)E F
;F G
services 
. 
AddTransient !
<! ")
IEventAdministratorRepository" ?
,? @(
EventAdministratorRepositoryA ]
>] ^
(^ _
)_ `
;` a
services 
. 
AddTransient !
<! " 
ICandidateRepository" 6
,6 7
CandidateRepository8 K
>K L
(L M
)M N
;N O
services 
. 
AddTransient !
<! "
IVoteRepository" 1
,1 2
VoteRepository3 A
>A B
(B C
)C D
;D E
services 
. 
AddTransient !
<! "
IUnitOfWork" -
,- .

UnitOfWork/ 9
.9 :

UnitOfWork: D
>D E
(E F
)F G
;G H
} 	
} 
} …
cC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\UnitOfWork\IUnitOfWork.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )

UnitOfWork) 3
{ 
public 

	interface 
IUnitOfWork  
{ 
WebApiDbContext 
Context 
{  !
get" %
;% &
}' (
void 
SaveChanges 
( 
) 
; 
}		 
}

 é
bC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\UnitOfWork\UnitOfWork.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 

Repository (
.( )

UnitOfWork) 3
{ 
public 

class 

UnitOfWork 
: 
IUnitOfWork )
{ 
public 
WebApiDbContext 
Context &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public		 

UnitOfWork		 
(		 
WebApiDbContext		 )
context		* 1
)		1 2
{

 	
Context 
= 
context 
; 
} 	
public 
void 
SaveChanges 
(  
)  !
{ 	
Context 
. 
SaveChanges 
(  
)  !
;! "
} 	
} 
} á
âC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\obj\Debug\net5.0\.NETCoreApp,Version=v5.0.AssemblyAttributes.cs
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
]| }»
âC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Repository\obj\Debug\net5.0\Dach.ElectionSystem.Repository.AssemblyInfo.cs
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
$str6 V
)V W
]W X
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
$str6 V
)V W
]W X
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
$str4 T
)T U
]U V
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