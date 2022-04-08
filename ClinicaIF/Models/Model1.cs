using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ClinicaIF.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<tbAlimento> tbAlimentoes { get; set; }
        public virtual DbSet<tbAntropometria> tbAntropometrias { get; set; }
        public virtual DbSet<tbCategoriaMedicamento> tbCategoriaMedicamentoes { get; set; }
        public virtual DbSet<tbCidade> tbCidades { get; set; }
        public virtual DbSet<tbContrato> tbContratoes { get; set; }
        public virtual DbSet<tbEscalaBristol> tbEscalaBristols { get; set; }
        public virtual DbSet<tbEscalaBristol_Paciente_Consulta> tbEscalaBristol_Paciente_Consulta { get; set; }
        public virtual DbSet<tbEstado> tbEstadoes { get; set; }
        public virtual DbSet<tbExame> tbExames { get; set; }
        public virtual DbSet<tbExame_X_Pacientes> tbExame_X_Pacientes { get; set; }
        public virtual DbSet<tbExameFisico> tbExameFisicoes { get; set; }
        public virtual DbSet<tbGrupoPatologico> tbGrupoPatologicoes { get; set; }
        public virtual DbSet<tbGrupoPatologico_X_Patologia> tbGrupoPatologico_X_Patologia { get; set; }
        public virtual DbSet<tbGruposReceitasDespesa> tbGruposReceitasDespesas { get; set; }
        public virtual DbSet<tbHistoriaPatologica> tbHistoriaPatologicas { get; set; }
        public virtual DbSet<tbHistoricoAlimentarNutricional> tbHistoricoAlimentarNutricionals { get; set; }
        public virtual DbSet<tbHistoricoDoencaAtual> tbHistoricoDoencaAtuals { get; set; }
        public virtual DbSet<tbHistoricoSocialAlimentar> tbHistoricoSocialAlimentars { get; set; }
        public virtual DbSet<tbHoraPaciente_Profissional> tbHoraPaciente_Profissional { get; set; }
        public virtual DbSet<tbLancarReceitasDespesa> tbLancarReceitasDespesas { get; set; }
        public virtual DbSet<tbMedicamento> tbMedicamentoes { get; set; }
        public virtual DbSet<tbMedico_Paciente> tbMedico_Paciente { get; set; }
        public virtual DbSet<tbPaciente> tbPacientes { get; set; }
        public virtual DbSet<tbPai> tbPais { get; set; }
        public virtual DbSet<tbPatologia> tbPatologias { get; set; }
        public virtual DbSet<tbPergunta> tbPerguntas { get; set; }
        public virtual DbSet<tbPlano> tbPlanoes { get; set; }
        public virtual DbSet<tbProfissional> tbProfissionals { get; set; }
        public virtual DbSet<tbRastreamentoMetabolico> tbRastreamentoMetabolicoes { get; set; }
        public virtual DbSet<tbRastreamentoResposta> tbRastreamentoRespostas { get; set; }
        public virtual DbSet<tbReceitaAlimentarPadrao> tbReceitaAlimentarPadraos { get; set; }
        public virtual DbSet<tbReceitaAlimentarPadrao_X_Alimento> tbReceitaAlimentarPadrao_X_Alimento { get; set; }
        public virtual DbSet<tbReceitaMedicaPadrao> tbReceitaMedicaPadraos { get; set; }
        public virtual DbSet<tbSubstancia> tbSubstancias { get; set; }
        public virtual DbSet<tbSuplemento> tbSuplementoes { get; set; }
        public virtual DbSet<tbTipoAcesso> tbTipoAcessoes { get; set; }
        public virtual DbSet<tbTipoProfissional> tbTipoProfissionals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<tbAlimento>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbAlimento>()
                .HasMany(e => e.tbReceitaAlimentarPadrao_X_Alimento)
                .WithRequired(e => e.tbAlimento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbCategoriaMedicamento>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbCategoriaMedicamento>()
                .Property(e => e.InformacaoComplementar)
                .IsUnicode(false);

            modelBuilder.Entity<tbCategoriaMedicamento>()
                .HasMany(e => e.tbMedicamentoes)
                .WithRequired(e => e.tbCategoriaMedicamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbCidade>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbCidade>()
                .HasMany(e => e.tbProfissionals)
                .WithRequired(e => e.tbCidade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbContrato>()
                .HasMany(e => e.tbProfissionals)
                .WithRequired(e => e.tbContrato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbEscalaBristol>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbEscalaBristol>()
                .HasMany(e => e.tbEscalaBristol_Paciente_Consulta)
                .WithRequired(e => e.tbEscalaBristol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbEstado>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbEstado>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<tbExame>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbExame>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<tbExame>()
                .HasMany(e => e.tbExame_X_Pacientes)
                .WithRequired(e => e.tbExame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbExame_X_Pacientes>()
                .Property(e => e.Resultado)
                .IsUnicode(false);

            modelBuilder.Entity<tbExameFisico>()
                .Property(e => e.TipoAtividadeFisica)
                .IsUnicode(false);

            modelBuilder.Entity<tbExameFisico>()
                .Property(e => e.PA)
                .IsUnicode(false);

            modelBuilder.Entity<tbExameFisico>()
                .Property(e => e.Obs)
                .IsUnicode(false);

            modelBuilder.Entity<tbGrupoPatologico>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbGrupoPatologico>()
                .HasMany(e => e.tbGrupoPatologico_X_Patologia)
                .WithRequired(e => e.tbGrupoPatologico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbGruposReceitasDespesa>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbGruposReceitasDespesa>()
                .HasMany(e => e.tbLancarReceitasDespesas)
                .WithRequired(e => e.tbGruposReceitasDespesa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbHistoriaPatologica>()
                .Property(e => e.Obs)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoAlimentarNutricional>()
                .Property(e => e.DescIntoleranciaAlimentar)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoAlimentarNutricional>()
                .Property(e => e.DescDietas)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoAlimentarNutricional>()
                .Property(e => e.DescMedicamentos)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoAlimentarNutricional>()
                .Property(e => e.DescExercicios)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoAlimentarNutricional>()
                .Property(e => e.DescOutros)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoAlimentarNutricional>()
                .Property(e => e.Obs)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoDoencaAtual>()
                .Property(e => e.Historico)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoDoencaAtual>()
                .Property(e => e.ObsNeoplasia)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoDoencaAtual>()
                .Property(e => e.ObsMetastase)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoDoencaAtual>()
                .Property(e => e.ObsQueimadura)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoDoencaAtual>()
                .Property(e => e.Outros)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.Profissao)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.RendaFamiliar)
                .HasPrecision(12, 2);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.Escolaridade)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.EstadoCivil)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.NomeCompraAlimento)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.NomeCozinhaAlimento)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.NomeRealizaRefeicao)
                .IsUnicode(false);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .Property(e => e.HoraInicioIndividual)
                .HasPrecision(0);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .Property(e => e.HoraFimIndividual)
                .HasPrecision(0);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .Property(e => e.Motivo)
                .IsUnicode(false);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .Property(e => e.Resumo)
                .IsUnicode(false);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .Property(e => e.Valor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .HasMany(e => e.tbAntropometrias)
                .WithRequired(e => e.tbHoraPaciente_Profissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .HasMany(e => e.tbEscalaBristol_Paciente_Consulta)
                .WithRequired(e => e.tbHoraPaciente_Profissional)
                .HasForeignKey(e => e.IdHora_Paciente_Profissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .HasMany(e => e.tbRastreamentoMetabolicoes)
                .WithRequired(e => e.tbHoraPaciente_Profissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbMedicamento>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbMedicamento>()
                .Property(e => e.Bula)
                .IsUnicode(false);

            modelBuilder.Entity<tbMedico_Paciente>()
                .Property(e => e.InformacaoResumida)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.RG)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.NomeResponsavel)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.Sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.TelResidencial)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.TelComercial)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.TelCelular)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.Profissao)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbAntropometrias)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbEscalaBristol_Paciente_Consulta)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbExame_X_Pacientes)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbHistoriaPatologicas)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbHistoricoAlimentarNutricionals)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbHistoricoDoencaAtuals)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbHistoricoSocialAlimentars)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbHoraPaciente_Profissional)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbMedico_Paciente)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPai>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbPai>()
                .Property(e => e.Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<tbPai>()
                .HasMany(e => e.tbEstadoes)
                .WithRequired(e => e.tbPai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPatologia>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbPatologia>()
                .Property(e => e.InformacaoComplementar)
                .IsUnicode(false);

            modelBuilder.Entity<tbPatologia>()
                .HasMany(e => e.tbGrupoPatologico_X_Patologia)
                .WithRequired(e => e.tbPatologia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPergunta>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbPergunta>()
                .HasMany(e => e.tbRastreamentoRespostas)
                .WithRequired(e => e.tbPergunta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPlano>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbPlano>()
                .Property(e => e.Valor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tbPlano>()
                .HasMany(e => e.tbContratoes)
                .WithRequired(e => e.tbPlano)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.CRM_CRN)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Especialidade)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Logradouro)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.DDD1)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.DDD2)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Telefone1)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Telefone2)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Salario)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tbProfissional>()
                .HasMany(e => e.tbHoraPaciente_Profissional)
                .WithRequired(e => e.tbProfissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbProfissional>()
                .HasMany(e => e.tbMedico_Paciente)
                .WithRequired(e => e.tbProfissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbProfissional>()
                .HasMany(e => e.tbPerguntas)
                .WithRequired(e => e.tbProfissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbProfissional>()
                .HasMany(e => e.tbReceitaMedicaPadraos)
                .WithRequired(e => e.tbProfissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbRastreamentoMetabolico>()
                .Property(e => e.ObsGeral)
                .IsUnicode(false);

            modelBuilder.Entity<tbRastreamentoResposta>()
                .Property(e => e.Obs)
                .IsUnicode(false);

            modelBuilder.Entity<tbRastreamentoResposta>()
                .HasMany(e => e.tbRastreamentoMetabolicoes)
                .WithRequired(e => e.tbRastreamentoResposta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbReceitaAlimentarPadrao>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbReceitaAlimentarPadrao>()
                .Property(e => e.InformacaoComplementar)
                .IsUnicode(false);

            modelBuilder.Entity<tbReceitaAlimentarPadrao>()
                .HasMany(e => e.tbReceitaAlimentarPadrao_X_Alimento)
                .WithRequired(e => e.tbReceitaAlimentarPadrao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbReceitaAlimentarPadrao_X_Alimento>()
                .Property(e => e.Periodicidade)
                .IsUnicode(false);

            modelBuilder.Entity<tbReceitaAlimentarPadrao_X_Alimento>()
                .Property(e => e.QuantoTempo)
                .IsUnicode(false);

            modelBuilder.Entity<tbReceitaMedicaPadrao>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbReceitaMedicaPadrao>()
                .Property(e => e.InformacaoComplementar)
                .IsUnicode(false);

            modelBuilder.Entity<tbSubstancia>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbSubstancia>()
                .Property(e => e.InformacaoComplementar)
                .IsUnicode(false);

            modelBuilder.Entity<tbSuplemento>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbTipoAcesso>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbTipoProfissional>()
                .Property(e => e.Nome)
                .IsUnicode(false);
        }
    }
}
