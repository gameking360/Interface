.assembly extern mscorlib {}
.assembly teste_f{}
.module teste_f.exe

.class public teste_f{
  .method static public void _principal(){
   .entrypoint
   .locals (int64 p)
   call string
        [mscorlib]System.Console::ReadLine()
   call int64 
        [mscorlib]System.Int64::Parse(string)
   stloc p
   ldc.i8 72
   conv.r8
   ldloc p
   conv.r8
   sub
   ldc.i8 18
   conv.r8
   cgt
   brfalse L2
   ldstr "insuficiente"
   call void 
        [mscorlib]System.Console::Write(string)
   br L1
L2:
   ldstr "suficiente"
   call void 
        [mscorlib]System.Console::Write(string)
L1:ret
  }
}
