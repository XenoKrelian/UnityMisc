using System;
using Tesla.Data;

namespace Tesla.Model.DTO
{
    [Serializable]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Tesla.Utils.DataTransferObjectBuilder", "0.0.0.3")]
    internal partial class AccountCanBeControlledByAccountViewDTO
    {
        public AccountCanBeControlledByAccountViewDTO() { }
        public AccountCanBeControlledByAccountViewDTO(AccountCanBeControlledByAccountView accountCanBeControlledByAccountView)
        {
            if (accountCanBeControlledByAccountView != null)
            {
                AccountId = accountCanBeControlledByAccountView.AccountId;
                CanBeControlledByAccountId = accountCanBeControlledByAccountView.CanBeControlledByAccountId;
                Level = accountCanBeControlledByAccountView.Level;
            }
        }

        public int AccountId { get; set; }
        public int CanBeControlledByAccountId { get; set; }
        public int? Level { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as AccountCanBeControlledByAccountViewDTO);
        }
        public bool Equals(AccountCanBeControlledByAccountViewDTO accountCanBeControlledByAccountViewDTO)
        {
            if (accountCanBeControlledByAccountViewDTO is null)
            {
                return false;
            }
            if (ReferenceEquals(this, accountCanBeControlledByAccountViewDTO))
            {
                return true;
            }
            if (accountCanBeControlledByAccountViewDTO.GetType() != GetType())
            {
                return false;
            }
            return (AccountId == accountCanBeControlledByAccountViewDTO.AccountId && CanBeControlledByAccountId == accountCanBeControlledByAccountViewDTO.CanBeControlledByAccountId && Level == accountCanBeControlledByAccountViewDTO.Level);
        }
        public override int GetHashCode()
        {
            return new { AccountId, CanBeControlledByAccountId, Level}.GetHashCode();
        }

        public static bool operator ==(AccountCanBeControlledByAccountViewDTO leftAccountCanBeControlledByAccountViewDTO, AccountCanBeControlledByAccountViewDTO rightAccountCanBeControlledByAccountViewDTO)
        {
            if (leftAccountCanBeControlledByAccountViewDTO is null)
            {
                return rightAccountCanBeControlledByAccountViewDTO is null;
            }
            return leftAccountCanBeControlledByAccountViewDTO.Equals(rightAccountCanBeControlledByAccountViewDTO);
        }
        public static bool operator !=(AccountCanBeControlledByAccountViewDTO leftAccountCanBeControlledByAccountViewDTO, AccountCanBeControlledByAccountViewDTO rightAccountCanBeControlledByAccountViewDTO)
        {
            return !(leftAccountCanBeControlledByAccountViewDTO == rightAccountCanBeControlledByAccountViewDTO);
        }
    }
    [Serializable]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Tesla.Utils.DataTransferObjectBuilder", "0.0.0.3")]
    internal partial class AccountPropertyDTO
    {
        public AccountPropertyDTO() { }
        public AccountPropertyDTO(AccountProperty accountProperty)
        {
            if (accountProperty != null)
            {
                AccountId = accountProperty.AccountId;
                FileDeletionRuleTypeKey = accountProperty.FileDeletionRuleTypeKey;
                VerifyAgainstLeakedPasswords = accountProperty.VerifyAgainstLeakedPasswords;
                StartDayOfWeekEnum = accountProperty.StartDayOfWeekEnum;
                LicenseCount = accountProperty.LicenseCount;
            }
        }

        public int AccountId { get; set; }
        public string FileDeletionRuleTypeKey { get; set; }
        public bool VerifyAgainstLeakedPasswords { get; set; }
        public int StartDayOfWeekEnum { get; set; }
        public int? LicenseCount { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as AccountPropertyDTO);
        }
        public bool Equals(AccountPropertyDTO accountPropertyDTO)
        {
            if (accountPropertyDTO is null)
            {
                return false;
            }
            if (ReferenceEquals(this, accountPropertyDTO))
            {
                return true;
            }
            if (accountPropertyDTO.GetType() != GetType())
            {
                return false;
            }
            return (AccountId == accountPropertyDTO.AccountId && FileDeletionRuleTypeKey == accountPropertyDTO.FileDeletionRuleTypeKey && VerifyAgainstLeakedPasswords == accountPropertyDTO.VerifyAgainstLeakedPasswords && StartDayOfWeekEnum == accountPropertyDTO.StartDayOfWeekEnum && LicenseCount == accountPropertyDTO.LicenseCount);
        }
        public override int GetHashCode()
        {
            return new { AccountId, FileDeletionRuleTypeKey, VerifyAgainstLeakedPasswords, StartDayOfWeekEnum, LicenseCount}.GetHashCode();
        }

        public static bool operator ==(AccountPropertyDTO leftAccountPropertyDTO, AccountPropertyDTO rightAccountPropertyDTO)
        {
            if (leftAccountPropertyDTO is null)
            {
                return rightAccountPropertyDTO is null;
            }
            return leftAccountPropertyDTO.Equals(rightAccountPropertyDTO);
        }
        public static bool operator !=(AccountPropertyDTO leftAccountPropertyDTO, AccountPropertyDTO rightAccountPropertyDTO)
        {
            return !(leftAccountPropertyDTO == rightAccountPropertyDTO);
        }
    }
    [Serializable]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Tesla.Utils.DataTransferObjectBuilder", "0.0.0.3")]
    internal partial class SecurityRoleDTO
    {
        public SecurityRoleDTO() { }
        public SecurityRoleDTO(SecurityRole securityRole)
        {
            if (securityRole != null)
            {
                SecurityRoleId = securityRole.SecurityRoleId;
                AccountId = securityRole.AccountId;
                Name = securityRole.Name;
                IsDeleted = securityRole.IsDeleted;
            }
        }

        public int SecurityRoleId { get; set; }
        public int? AccountId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SecurityRoleDTO);
        }
        public bool Equals(SecurityRoleDTO securityRoleDTO)
        {
            if (securityRoleDTO is null)
            {
                return false;
            }
            if (ReferenceEquals(this, securityRoleDTO))
            {
                return true;
            }
            if (securityRoleDTO.GetType() != GetType())
            {
                return false;
            }
            return (SecurityRoleId == securityRoleDTO.SecurityRoleId && AccountId == securityRoleDTO.AccountId && Name == securityRoleDTO.Name && IsDeleted == securityRoleDTO.IsDeleted);
        }
        public override int GetHashCode()
        {
            return new { SecurityRoleId, AccountId, Name, IsDeleted}.GetHashCode();
        }

        public static bool operator ==(SecurityRoleDTO leftSecurityRoleDTO, SecurityRoleDTO rightSecurityRoleDTO)
        {
            if (leftSecurityRoleDTO is null)
            {
                return rightSecurityRoleDTO is null;
            }
            return leftSecurityRoleDTO.Equals(rightSecurityRoleDTO);
        }
        public static bool operator !=(SecurityRoleDTO leftSecurityRoleDTO, SecurityRoleDTO rightSecurityRoleDTO)
        {
            return !(leftSecurityRoleDTO == rightSecurityRoleDTO);
        }
    }
    [Serializable]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Tesla.Utils.DataTransferObjectBuilder", "0.0.0.3")]
    internal partial class SecurityRoleTranslationDTO
    {
        public SecurityRoleTranslationDTO() { }
        public SecurityRoleTranslationDTO(SecurityRoleTranslation securityRoleTranslation)
        {
            if (securityRoleTranslation != null)
            {
                SecurityRoleId = securityRoleTranslation.SecurityRoleId;
                LanguageKey = securityRoleTranslation.LanguageKey;
                RoleName = securityRoleTranslation.RoleName;
                RoleDescription = securityRoleTranslation.RoleDescription;
            }
        }

        public int SecurityRoleId { get; set; }
        public string LanguageKey { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SecurityRoleTranslationDTO);
        }
        public bool Equals(SecurityRoleTranslationDTO securityRoleTranslationDTO)
        {
            if (securityRoleTranslationDTO is null)
            {
                return false;
            }
            if (ReferenceEquals(this, securityRoleTranslationDTO))
            {
                return true;
            }
            if (securityRoleTranslationDTO.GetType() != GetType())
            {
                return false;
            }
            return (SecurityRoleId == securityRoleTranslationDTO.SecurityRoleId && LanguageKey == securityRoleTranslationDTO.LanguageKey && RoleName == securityRoleTranslationDTO.RoleName && RoleDescription == securityRoleTranslationDTO.RoleDescription);
        }
        public override int GetHashCode()
        {
            return new { SecurityRoleId, LanguageKey, RoleName, RoleDescription}.GetHashCode();
        }

        public static bool operator ==(SecurityRoleTranslationDTO leftSecurityRoleTranslationDTO, SecurityRoleTranslationDTO rightSecurityRoleTranslationDTO)
        {
            if (leftSecurityRoleTranslationDTO is null)
            {
                return rightSecurityRoleTranslationDTO is null;
            }
            return leftSecurityRoleTranslationDTO.Equals(rightSecurityRoleTranslationDTO);
        }
        public static bool operator !=(SecurityRoleTranslationDTO leftSecurityRoleTranslationDTO, SecurityRoleTranslationDTO rightSecurityRoleTranslationDTO)
        {
            return !(leftSecurityRoleTranslationDTO == rightSecurityRoleTranslationDTO);
        }
    }
    [Serializable]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Tesla.Utils.DataTransferObjectBuilder", "0.0.0.3")]
    internal partial class SecurityRoleRelAccountTranslationDTO
    {
        public SecurityRoleRelAccountTranslationDTO() { }
        public SecurityRoleRelAccountTranslationDTO(SecurityRoleRelAccountTranslation securityRoleRelAccountTranslation)
        {
            if (securityRoleRelAccountTranslation != null)
            {
                SecurityRoleId = securityRoleRelAccountTranslation.SecurityRoleId;
                LanguageKey = securityRoleRelAccountTranslation.LanguageKey;
                RoleName = securityRoleRelAccountTranslation.RoleName;
                RoleDescription = securityRoleRelAccountTranslation.RoleDescription;
                AccountId = securityRoleRelAccountTranslation.AccountId;
            }
        }

        public int SecurityRoleId { get; set; }
        public string LanguageKey { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public int AccountId { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SecurityRoleRelAccountTranslationDTO);
        }
        public bool Equals(SecurityRoleRelAccountTranslationDTO securityRoleRelAccountTranslationDTO)
        {
            if (securityRoleRelAccountTranslationDTO is null)
            {
                return false;
            }
            if (ReferenceEquals(this, securityRoleRelAccountTranslationDTO))
            {
                return true;
            }
            if (securityRoleRelAccountTranslationDTO.GetType() != GetType())
            {
                return false;
            }
            return (SecurityRoleId == securityRoleRelAccountTranslationDTO.SecurityRoleId && LanguageKey == securityRoleRelAccountTranslationDTO.LanguageKey && RoleName == securityRoleRelAccountTranslationDTO.RoleName && RoleDescription == securityRoleRelAccountTranslationDTO.RoleDescription && AccountId == securityRoleRelAccountTranslationDTO.AccountId);
        }
        public override int GetHashCode()
        {
            return new { SecurityRoleId, LanguageKey, RoleName, RoleDescription, AccountId}.GetHashCode();
        }

        public static bool operator ==(SecurityRoleRelAccountTranslationDTO leftSecurityRoleRelAccountTranslationDTO, SecurityRoleRelAccountTranslationDTO rightSecurityRoleRelAccountTranslationDTO)
        {
            if (leftSecurityRoleRelAccountTranslationDTO is null)
            {
                return rightSecurityRoleRelAccountTranslationDTO is null;
            }
            return leftSecurityRoleRelAccountTranslationDTO.Equals(rightSecurityRoleRelAccountTranslationDTO);
        }
        public static bool operator !=(SecurityRoleRelAccountTranslationDTO leftSecurityRoleRelAccountTranslationDTO, SecurityRoleRelAccountTranslationDTO rightSecurityRoleRelAccountTranslationDTO)
        {
            return !(leftSecurityRoleRelAccountTranslationDTO == rightSecurityRoleRelAccountTranslationDTO);
        }
    }
    [Serializable]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Tesla.Utils.DataTransferObjectBuilder", "0.0.0.3")]
    internal partial class UserPropertyDTO
    {
        public UserPropertyDTO() { }
        public UserPropertyDTO(UserProperty userProperty)
        {
            if (userProperty != null)
            {
                UserId = userProperty.UserId;
                UserExternalId = userProperty.UserExternalId;
                UserExternalIdSchemeKey = userProperty.UserExternalIdSchemeKey;
                FirstName = userProperty.FirstName;
                LastName = userProperty.LastName;
                GenderKey = userProperty.GenderKey;
                Birthdate = userProperty.Birthdate;
                AddressId = userProperty.AddressId;
                PhoneNo = userProperty.PhoneNo;
                PhoneNoMobile = userProperty.PhoneNoMobile;
                PhoneNoPrivate = userProperty.PhoneNoPrivate;
                EmailPrivate = userProperty.EmailPrivate;
                DepartmentId = userProperty.DepartmentId;
                ProfileImageFileId = userProperty.ProfileImageFileId;
                LanguageKey = userProperty.LanguageKey;
                ForcePasswordChange = userProperty.ForcePasswordChange;
                ExportBlockedUntil = userProperty.ExportBlockedUntil;
                DeactivateDateTimeOffset = userProperty.DeactivateDateTimeOffset;
                PaycheckNumber = userProperty.PaycheckNumber;
                AlertNewOpenNotificationIntervalKey = userProperty.AlertNewOpenNotificationIntervalKey;
                LastAlertNewOpenNotifications = userProperty.LastAlertNewOpenNotifications;
                TimeZoneId = userProperty.TimeZoneId;
            }
        }

        public int UserId { get; set; }
        public string UserExternalId { get; set; }
        public string UserExternalIdSchemeKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GenderKey { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? AddressId { get; set; }
        public string PhoneNo { get; set; }
        public string PhoneNoMobile { get; set; }
        public string PhoneNoPrivate { get; set; }
        public string EmailPrivate { get; set; }
        public int? DepartmentId { get; set; }
        public int? ProfileImageFileId { get; set; }
        public string LanguageKey { get; set; }
        public bool ForcePasswordChange { get; set; }
        public DateTime? ExportBlockedUntil { get; set; }
        public DateTimeOffset? DeactivateDateTimeOffset { get; set; }
        public string PaycheckNumber { get; set; }
        public string AlertNewOpenNotificationIntervalKey { get; set; }
        public DateTime? LastAlertNewOpenNotifications { get; set; }
        public string TimeZoneId { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as UserPropertyDTO);
        }
        public bool Equals(UserPropertyDTO userPropertyDTO)
        {
            if (userPropertyDTO is null)
            {
                return false;
            }
            if (ReferenceEquals(this, userPropertyDTO))
            {
                return true;
            }
            if (userPropertyDTO.GetType() != GetType())
            {
                return false;
            }
            return (UserId == userPropertyDTO.UserId && UserExternalId == userPropertyDTO.UserExternalId && UserExternalIdSchemeKey == userPropertyDTO.UserExternalIdSchemeKey && FirstName == userPropertyDTO.FirstName && LastName == userPropertyDTO.LastName && GenderKey == userPropertyDTO.GenderKey && Birthdate == userPropertyDTO.Birthdate && AddressId == userPropertyDTO.AddressId && PhoneNo == userPropertyDTO.PhoneNo && PhoneNoMobile == userPropertyDTO.PhoneNoMobile && PhoneNoPrivate == userPropertyDTO.PhoneNoPrivate && EmailPrivate == userPropertyDTO.EmailPrivate && DepartmentId == userPropertyDTO.DepartmentId && ProfileImageFileId == userPropertyDTO.ProfileImageFileId && LanguageKey == userPropertyDTO.LanguageKey && ForcePasswordChange == userPropertyDTO.ForcePasswordChange && ExportBlockedUntil == userPropertyDTO.ExportBlockedUntil && DeactivateDateTimeOffset == userPropertyDTO.DeactivateDateTimeOffset && PaycheckNumber == userPropertyDTO.PaycheckNumber && AlertNewOpenNotificationIntervalKey == userPropertyDTO.AlertNewOpenNotificationIntervalKey && LastAlertNewOpenNotifications == userPropertyDTO.LastAlertNewOpenNotifications && TimeZoneId == userPropertyDTO.TimeZoneId);
        }
        public override int GetHashCode()
        {
            return new { UserId, UserExternalId, UserExternalIdSchemeKey, FirstName, LastName, GenderKey, Birthdate, AddressId, PhoneNo, PhoneNoMobile, PhoneNoPrivate, EmailPrivate, DepartmentId, ProfileImageFileId, LanguageKey, ForcePasswordChange, ExportBlockedUntil, DeactivateDateTimeOffset, PaycheckNumber, AlertNewOpenNotificationIntervalKey, LastAlertNewOpenNotifications, TimeZoneId}.GetHashCode();
        }

        public static bool operator ==(UserPropertyDTO leftUserPropertyDTO, UserPropertyDTO rightUserPropertyDTO)
        {
            if (leftUserPropertyDTO is null)
            {
                return rightUserPropertyDTO is null;
            }
            return leftUserPropertyDTO.Equals(rightUserPropertyDTO);
        }
        public static bool operator !=(UserPropertyDTO leftUserPropertyDTO, UserPropertyDTO rightUserPropertyDTO)
        {
            return !(leftUserPropertyDTO == rightUserPropertyDTO);
        }
    }
    [Serializable]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Tesla.Utils.DataTransferObjectBuilder", "0.0.0.3")]
    internal partial class SystemSettingDTO
    {
        public SystemSettingDTO() { }
        public SystemSettingDTO(SystemSetting systemSetting)
        {
            if (systemSetting != null)
            {
                Lock = systemSetting.Lock;
                RequireAccounts = systemSetting.RequireAccounts;
                UseAccountAllowedDomains = systemSetting.UseAccountAllowedDomains;
            }
        }

        public string Lock { get; set; }
        public bool RequireAccounts { get; set; }
        public bool UseAccountAllowedDomains { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SystemSettingDTO);
        }
        public bool Equals(SystemSettingDTO systemSettingDTO)
        {
            if (systemSettingDTO is null)
            {
                return false;
            }
            if (ReferenceEquals(this, systemSettingDTO))
            {
                return true;
            }
            if (systemSettingDTO.GetType() != GetType())
            {
                return false;
            }
            return (Lock == systemSettingDTO.Lock && RequireAccounts == systemSettingDTO.RequireAccounts && UseAccountAllowedDomains == systemSettingDTO.UseAccountAllowedDomains);
        }
        public override int GetHashCode()
        {
            return new { Lock, RequireAccounts, UseAccountAllowedDomains}.GetHashCode();
        }

        public static bool operator ==(SystemSettingDTO leftSystemSettingDTO, SystemSettingDTO rightSystemSettingDTO)
        {
            if (leftSystemSettingDTO is null)
            {
                return rightSystemSettingDTO is null;
            }
            return leftSystemSettingDTO.Equals(rightSystemSettingDTO);
        }
        public static bool operator !=(SystemSettingDTO leftSystemSettingDTO, SystemSettingDTO rightSystemSettingDTO)
        {
            return !(leftSystemSettingDTO == rightSystemSettingDTO);
        }
    }
    [Serializable]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Tesla.Utils.DataTransferObjectBuilder", "0.0.0.3")]
    internal partial class CalendarEntryDTO
    {
        public CalendarEntryDTO() { }
        public CalendarEntryDTO(CalendarEntry calendarEntry)
        {
            if (calendarEntry != null)
            {
                CalendarEntryId = calendarEntry.CalendarEntryId;
                CalendarEntryTypeKey = calendarEntry.CalendarEntryTypeKey;
                UserId = calendarEntry.UserId;
                StartDateTimeOffset = calendarEntry.StartDateTimeOffset;
                EndDateTimeOffset = calendarEntry.EndDateTimeOffset;
                Title = calendarEntry.Title;
                Location = calendarEntry.Location;
                Notes = calendarEntry.Notes;
                IsBusy = calendarEntry.IsBusy;
                RecurrencePattern = calendarEntry.RecurrencePattern;
                RecurrencePatternEndDateTimeOffset = calendarEntry.RecurrencePatternEndDateTimeOffset;
            }
        }

        public int CalendarEntryId { get; set; }
        public string CalendarEntryTypeKey { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset StartDateTimeOffset { get; set; }
        public DateTimeOffset EndDateTimeOffset { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public bool IsBusy { get; set; }
        public string RecurrencePattern { get; set; }
        public DateTimeOffset RecurrencePatternEndDateTimeOffset { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as CalendarEntryDTO);
        }
        public bool Equals(CalendarEntryDTO calendarEntryDTO)
        {
            if (calendarEntryDTO is null)
            {
                return false;
            }
            if (ReferenceEquals(this, calendarEntryDTO))
            {
                return true;
            }
            if (calendarEntryDTO.GetType() != GetType())
            {
                return false;
            }
            return (CalendarEntryId == calendarEntryDTO.CalendarEntryId && CalendarEntryTypeKey == calendarEntryDTO.CalendarEntryTypeKey && UserId == calendarEntryDTO.UserId && StartDateTimeOffset == calendarEntryDTO.StartDateTimeOffset && EndDateTimeOffset == calendarEntryDTO.EndDateTimeOffset && Title == calendarEntryDTO.Title && Location == calendarEntryDTO.Location && Notes == calendarEntryDTO.Notes && IsBusy == calendarEntryDTO.IsBusy && RecurrencePattern == calendarEntryDTO.RecurrencePattern && RecurrencePatternEndDateTimeOffset == calendarEntryDTO.RecurrencePatternEndDateTimeOffset);
        }
        public override int GetHashCode()
        {
            return new { CalendarEntryId, CalendarEntryTypeKey, UserId, StartDateTimeOffset, EndDateTimeOffset, Title, Location, Notes, IsBusy, RecurrencePattern, RecurrencePatternEndDateTimeOffset}.GetHashCode();
        }

        public static bool operator ==(CalendarEntryDTO leftCalendarEntryDTO, CalendarEntryDTO rightCalendarEntryDTO)
        {
            if (leftCalendarEntryDTO is null)
            {
                return rightCalendarEntryDTO is null;
            }
            return leftCalendarEntryDTO.Equals(rightCalendarEntryDTO);
        }
        public static bool operator !=(CalendarEntryDTO leftCalendarEntryDTO, CalendarEntryDTO rightCalendarEntryDTO)
        {
            return !(leftCalendarEntryDTO == rightCalendarEntryDTO);
        }
    }
    [Serializable]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Tesla.Utils.DataTransferObjectBuilder", "0.0.0.3")]
    internal partial class CalendarRecurrenceExceptionDateDTO
    {
        public CalendarRecurrenceExceptionDateDTO() { }
        public CalendarRecurrenceExceptionDateDTO(CalendarRecurrenceExceptionDate calendarRecurrenceExceptionDate)
        {
            if (calendarRecurrenceExceptionDate != null)
            {
                CalendarEntryId = calendarRecurrenceExceptionDate.CalendarEntryId;
                RecurrenceExceptionDateTimeOffset = calendarRecurrenceExceptionDate.RecurrenceExceptionDateTimeOffset;
                NewCalendarEntryId = calendarRecurrenceExceptionDate.NewCalendarEntryId;
            }
        }

        public int CalendarEntryId { get; set; }
        public DateTimeOffset RecurrenceExceptionDateTimeOffset { get; set; }
        public int? NewCalendarEntryId { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as CalendarRecurrenceExceptionDateDTO);
        }
        public bool Equals(CalendarRecurrenceExceptionDateDTO calendarRecurrenceExceptionDateDTO)
        {
            if (calendarRecurrenceExceptionDateDTO is null)
            {
                return false;
            }
            if (ReferenceEquals(this, calendarRecurrenceExceptionDateDTO))
            {
                return true;
            }
            if (calendarRecurrenceExceptionDateDTO.GetType() != GetType())
            {
                return false;
            }
            return (CalendarEntryId == calendarRecurrenceExceptionDateDTO.CalendarEntryId && RecurrenceExceptionDateTimeOffset == calendarRecurrenceExceptionDateDTO.RecurrenceExceptionDateTimeOffset && NewCalendarEntryId == calendarRecurrenceExceptionDateDTO.NewCalendarEntryId);
        }
        public override int GetHashCode()
        {
            return new { CalendarEntryId, RecurrenceExceptionDateTimeOffset, NewCalendarEntryId}.GetHashCode();
        }

        public static bool operator ==(CalendarRecurrenceExceptionDateDTO leftCalendarRecurrenceExceptionDateDTO, CalendarRecurrenceExceptionDateDTO rightCalendarRecurrenceExceptionDateDTO)
        {
            if (leftCalendarRecurrenceExceptionDateDTO is null)
            {
                return rightCalendarRecurrenceExceptionDateDTO is null;
            }
            return leftCalendarRecurrenceExceptionDateDTO.Equals(rightCalendarRecurrenceExceptionDateDTO);
        }
        public static bool operator !=(CalendarRecurrenceExceptionDateDTO leftCalendarRecurrenceExceptionDateDTO, CalendarRecurrenceExceptionDateDTO rightCalendarRecurrenceExceptionDateDTO)
        {
            return !(leftCalendarRecurrenceExceptionDateDTO == rightCalendarRecurrenceExceptionDateDTO);
        }
    }
    [Serializable]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Tesla.Utils.DataTransferObjectBuilder", "0.0.0.3")]
    internal partial class CalendarReminderDTO
    {
        public CalendarReminderDTO() { }
        public CalendarReminderDTO(CalendarReminder calendarReminder)
        {
            if (calendarReminder != null)
            {
                CalendarReminderId = calendarReminder.CalendarReminderId;
                CalendarEntryId = calendarReminder.CalendarEntryId;
                UserId = calendarReminder.UserId;
                MinutesBefore = calendarReminder.MinutesBefore;
                LastEventNotifiedDateTime = calendarReminder.LastEventNotifiedDateTime;
            }
        }

        public int CalendarReminderId { get; set; }
        public int CalendarEntryId { get; set; }
        public int UserId { get; set; }
        public int MinutesBefore { get; set; }
        public DateTime? LastEventNotifiedDateTime { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as CalendarReminderDTO);
        }
        public bool Equals(CalendarReminderDTO calendarReminderDTO)
        {
            if (calendarReminderDTO is null)
            {
                return false;
            }
            if (ReferenceEquals(this, calendarReminderDTO))
            {
                return true;
            }
            if (calendarReminderDTO.GetType() != GetType())
            {
                return false;
            }
            return (CalendarReminderId == calendarReminderDTO.CalendarReminderId && CalendarEntryId == calendarReminderDTO.CalendarEntryId && UserId == calendarReminderDTO.UserId && MinutesBefore == calendarReminderDTO.MinutesBefore && LastEventNotifiedDateTime == calendarReminderDTO.LastEventNotifiedDateTime);
        }
        public override int GetHashCode()
        {
            return new { CalendarReminderId, CalendarEntryId, UserId, MinutesBefore, LastEventNotifiedDateTime}.GetHashCode();
        }

        public static bool operator ==(CalendarReminderDTO leftCalendarReminderDTO, CalendarReminderDTO rightCalendarReminderDTO)
        {
            if (leftCalendarReminderDTO is null)
            {
                return rightCalendarReminderDTO is null;
            }
            return leftCalendarReminderDTO.Equals(rightCalendarReminderDTO);
        }
        public static bool operator !=(CalendarReminderDTO leftCalendarReminderDTO, CalendarReminderDTO rightCalendarReminderDTO)
        {
            return !(leftCalendarReminderDTO == rightCalendarReminderDTO);
        }
    }
    [Serializable]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Tesla.Utils.DataTransferObjectBuilder", "0.0.0.3")]
    internal partial class ModuleTranslationDTO
    {
        public ModuleTranslationDTO() { }
        public ModuleTranslationDTO(ModuleTranslation moduleTranslation)
        {
            if (moduleTranslation != null)
            {
                ModuleKey = moduleTranslation.ModuleKey;
                LanguageKey = moduleTranslation.LanguageKey;
                ModuleName = moduleTranslation.ModuleName;
            }
        }

        public string ModuleKey { get; set; }
        public string LanguageKey { get; set; }
        public string ModuleName { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ModuleTranslationDTO);
        }
        public bool Equals(ModuleTranslationDTO moduleTranslationDTO)
        {
            if (moduleTranslationDTO is null)
            {
                return false;
            }
            if (ReferenceEquals(this, moduleTranslationDTO))
            {
                return true;
            }
            if (moduleTranslationDTO.GetType() != GetType())
            {
                return false;
            }
            return (ModuleKey == moduleTranslationDTO.ModuleKey && LanguageKey == moduleTranslationDTO.LanguageKey && ModuleName == moduleTranslationDTO.ModuleName);
        }
        public override int GetHashCode()
        {
            return new { ModuleKey, LanguageKey, ModuleName}.GetHashCode();
        }

        public static bool operator ==(ModuleTranslationDTO leftModuleTranslationDTO, ModuleTranslationDTO rightModuleTranslationDTO)
        {
            if (leftModuleTranslationDTO is null)
            {
                return rightModuleTranslationDTO is null;
            }
            return leftModuleTranslationDTO.Equals(rightModuleTranslationDTO);
        }
        public static bool operator !=(ModuleTranslationDTO leftModuleTranslationDTO, ModuleTranslationDTO rightModuleTranslationDTO)
        {
            return !(leftModuleTranslationDTO == rightModuleTranslationDTO);
        }
    }
}

