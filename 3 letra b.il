// 3 letra b

.assembly extern mscorlib {}
.assembly _programa{}
.module _programa.exe

.class public _unica {
.method static public void _principal() {
.entrypoint
.locals (int64 anoNascimento, int64 idade)


ldstr "digite seu ano de nascimento:  "
call void [mscorlib] System.Console::Write(string)


call string [mscorlib] System.Console::ReadLine()
call int64 [mscorlib] System.Int64::Parse(string)

stloc anoNascimento
ldc.i8 2025
ldloc anoNascimento
sub
stloc idade
ldloc idade
ldc.i8 16
clt
brtrue L1

ldloc idade
ldc.i8 18

clt 
brtrue L2

br L3


L1: 
ldstr "representanda"
call void [mscorlib] System.Console::Write(string)
ret

L2:
ldstr "assistida"
call void [mscorlib] System.Console::Write(string)
ret

L3:
ldstr "maior de idade"
call void [mscorlib] System.Console::Write(string)
ret


}
}