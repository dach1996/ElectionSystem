ªV
MC:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Common\Util.cs
	namespace 	
Dach
 
. 
ElectionSystem 
. 
Common $
{ 
public 

static 
class 
Util 
{		 
public 
static 
string 
	GetSHA256 &
(& '
string' -
input. 3
)3 4
{ 	
try 
{ 
using 
SHA256 
sha256 #
=$ %
SHA256Managed& 3
.3 4
Create4 :
(: ;
); <
;< =
ASCIIEncoding 
encoding &
=' (
new) ,
(, -
)- .
;. /
byte 
[ 
] 
stream 
= 
null  $
;$ %
stream 
= 
sha256 
.  
ComputeHash  +
(+ ,
encoding, 4
.4 5
GetBytes5 =
(= >
input> C
)C D
)D E
;E F
StringBuilder 
sb  
=! "
new# &
(& '
)' (
;( )
for 
( 
int 
i 
= 
$num 
; 
i  !
<" #
stream$ *
.* +
Length+ 1
;1 2
i3 4
++4 6
)6 7
sb 
. 
AppendFormat #
(# $
$str$ ,
,, -
stream. 4
[4 5
i5 6
]6 7
)7 8
;8 9
return 
sb 
. 
ToString "
(" #
)# $
;$ %
} 
catch 
{ 
return   
input   
;   
}!! 
}"" 	
public** 
static** 
string** 
ComputeSHA256** *
(*** +
string**+ 1
input**2 7
,**7 8
string**9 ?
salt**@ D
)**D E
{++ 	
using,, 
SHA256,, 
sha256,, 
=,,  !
SHA256Managed,," /
.,,/ 0
Create,,0 6
(,,6 7
),,7 8
;,,8 9
byte-- 
[-- 
]-- 
	saltBytes-- 
=-- 
Encoding-- '
.--' (
UTF8--( ,
.--, -
GetBytes--- 5
(--5 6
salt--6 :
)--: ;
;--; <
byte.. 
[.. 
].. 

inputBytes.. 
=.. 
Encoding..  (
...( )
UTF8..) -
...- .
GetBytes... 6
(..6 7
input..7 <
)..< =
;..= >
byte00 
[00 
]00 
saltedInput00 
=00  
new00! $
byte00% )
[00) *
	saltBytes00* 3
.003 4
Length004 :
+00; <

inputBytes00= G
.00G H
Length00H N
]00N O
;00O P
	saltBytes11 
.11 
CopyTo11 
(11 
saltedInput11 (
,11( )
$num11* +
)11+ ,
;11, -

inputBytes22 
.22 
CopyTo22 
(22 
saltedInput22 )
,22) *
	saltBytes22+ 4
.224 5
Length225 ;
)22; <
;22< =
byte33 
[33 
]33 
hashedBytes33 
=33  
sha25633! '
.33' (
ComputeHash33( 3
(333 4
saltedInput334 ?
)33? @
;33@ A
StringBuilder44 
sb44 
=44 
new44 "
(44" #
)44# $
;44$ %
for55 
(55 
int55 
i55 
=55 
$num55 
;55 
i55 
<55 
hashedBytes55  +
.55+ ,
Length55, 2
;552 3
i554 5
++555 7
)557 8
sb66 
.66 
AppendFormat66 
(66  
$str66  (
,66( )
hashedBytes66* 5
[665 6
i666 7
]667 8
)668 9
;669 :
return77 
sb77 
.77 
ToString77 
(77 
)77  
;77  !
}88 	
public@@ 
static@@ 
bool@@  
VerifyPasswordSHA256@@ /
(@@/ 0
string@@0 6
password@@7 ?
,@@? @
string@@A G
input@@H M
,@@M N
string@@O U
salt@@V Z
)@@Z [
{AA 	
varBB 
hashInputSaltBB 
=BB 
StringBB  &
.BB& '
EmptyBB' ,
;BB, -
usingCC 
(CC 
SHA256CC 
sha256CC  
=CC! "
SHA256ManagedCC# 0
.CC0 1
CreateCC1 7
(CC7 8
)CC8 9
)CC9 :
{DD 
byteEE 
[EE 
]EE 
	saltBytesEE  
=EE! "
EncodingEE# +
.EE+ ,
UTF8EE, 0
.EE0 1
GetBytesEE1 9
(EE9 :
saltEE: >
)EE> ?
;EE? @
byteFF 
[FF 
]FF 

inputBytesFF !
=FF" #
EncodingFF$ ,
.FF, -
UTF8FF- 1
.FF1 2
GetBytesFF2 :
(FF: ;
inputFF; @
)FF@ A
;FFA B
byteHH 
[HH 
]HH 
saltedInputHH "
=HH# $
newHH% (
byteHH) -
[HH- .
	saltBytesHH. 7
.HH7 8
LengthHH8 >
+HH? @

inputBytesHHA K
.HHK L
LengthHHL R
]HHR S
;HHS T
	saltBytesII 
.II 
CopyToII  
(II  !
saltedInputII! ,
,II, -
$numII. /
)II/ 0
;II0 1

inputBytesJJ 
.JJ 
CopyToJJ !
(JJ! "
saltedInputJJ" -
,JJ- .
	saltBytesJJ/ 8
.JJ8 9
LengthJJ9 ?
)JJ? @
;JJ@ A
byteKK 
[KK 
]KK 
hashedBytesKK "
=KK# $
sha256KK% +
.KK+ ,
ComputeHashKK, 7
(KK7 8
saltedInputKK8 C
)KKC D
;KKD E
hashInputSaltLL 
=LL 
BitConverterLL  ,
.LL, -
ToStringLL- 5
(LL5 6
hashedBytesLL6 A
)LLA B
;LLB C
}MM 
returnNN 
hashInputSaltNN  
==NN! #
passwordNN$ ,
;NN, -
}OO 	
publicRR 
staticRR 
voidRR 
CopyPropertiesToRR +
<RR+ ,
TRR, -
,RR- .
TURR/ 1
>RR1 2
(RR2 3
thisRR3 7
TRR8 9
sourceRR: @
,RR@ A
TURRB D
destRRE I
)RRI J
{SS 	
varTT 
sourcePropsTT 
=TT 
typeofTT $
(TT$ %
TTT% &
)TT& '
.TT' (
GetPropertiesTT( 5
(TT5 6
)TT6 7
.TT7 8
WhereTT8 =
(TT= >
xTT> ?
=>TT@ B
xTTC D
.TTD E
CanReadTTE L
)TTL M
.TTM N
ToListTTN T
(TTT U
)TTU V
;TTV W
varUU 
	destPropsUU 
=UU 
typeofUU "
(UU" #
TUUU# %
)UU% &
.UU& '
GetPropertiesUU' 4
(UU4 5
)UU5 6
.VV 
WhereVV 
(VV 
xVV 
=>VV 
xVV  !
.VV! "
CanWriteVV" *
)VV* +
.WW 
ToListWW 
(WW 
)WW 
;WW 
foreachXX 
(XX 
varXX 

sourcePropXX #
inXX$ &
sourcePropsXX' 2
)XX2 3
{YY 
ifZZ 
(ZZ 
	destPropsZZ 
.ZZ 
AnyZZ !
(ZZ! "
xZZ" #
=>ZZ$ &
xZZ' (
.ZZ( )
NameZZ) -
==ZZ. 0

sourcePropZZ1 ;
.ZZ; <
NameZZ< @
)ZZ@ A
)ZZA B
{[[ 
var\\ 
p\\ 
=\\ 
	destProps\\ %
.\\% &
First\\& +
(\\+ ,
x\\, -
=>\\. 0
x\\1 2
.\\2 3
Name\\3 7
==\\8 :

sourceProp\\; E
.\\E F
Name\\F J
)\\J K
;\\K L
if]] 
(]] 
p]] 
.]] 
CanWrite]] "
)]]" #
{^^ 
p__ 
.__ 
SetValue__ "
(__" #
dest__# '
,__' (

sourceProp__) 3
.__3 4
GetValue__4 <
(__< =
source__= C
,__C D
null__E I
)__I J
,__J K
null__L P
)__P Q
;__Q R
}`` 
}aa 
}cc 
}ee 	
publicll 
staticll 
stringll 
GenerateCodell )
(ll) *
intll* -
numberCharactersll. >
)ll> ?
{mm 	
varnn 
allowableCharsnn 
=nn  
$strnn! G
;nnG H
varoo 
randomoo 
=oo 
newoo 
byteoo !
[oo! "
numberCharactersoo" 2
]oo2 3
;oo3 4
usingqq 
(qq 
varqq 
rngqq 
=qq 
newqq  $
RNGCryptoServiceProviderqq! 9
(qq9 :
)qq: ;
)qq; <
rngrr 
.rr 
GetBytesrr 
(rr 
randomrr #
)rr# $
;rr$ %
vartt 
characteresArraytt  
=tt! "
allowableCharstt# 1
.tt1 2
ToCharArraytt2 =
(tt= >
)tt> ?
;tt? @
varvv "
characteresArraylengthvv &
=vv' (
characteresArrayvv) 9
.vv9 :
Lengthvv: @
;vv@ A
varww 
charsww 
=ww 
newww 
charww  
[ww  !
numberCharactersww! 1
]ww1 2
;ww2 3
forxx 
(xx 
varxx 
ixx 
=xx 
$numxx 
;xx 
ixx 
<xx 
numberCharactersxx  0
;xx0 1
ixx2 3
++xx3 5
)xx5 6
charsyy 
[yy 
iyy 
]yy 
=yy 
characteresArrayyy +
[yy+ ,
randomyy, 2
[yy2 3
iyy3 4
]yy4 5
%yy6 7"
characteresArraylengthyy8 N
]yyN O
;yyO P
returnzz 
newzz 
stringzz 
(zz 
charszz #
)zz# $
;zz$ %
}{{ 	
}~~ 
} ƒ
…C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Common\obj\Debug\net5.0\.NETCoreApp,Version=v5.0.AssemblyAttributes.cs
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
]| }À
C:\Users\wwwda\source\repos\ElectionSystem\Dach.ElectionSystem.Common\obj\Debug\net5.0\Dach.ElectionSystem.Common.AssemblyInfo.cs
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
$str6 R
)R S
]S T
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
$str6 R
)R S
]S T
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
$str4 P
)P Q
]Q R
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