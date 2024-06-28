using DotNetBankingAppClientContracts.Dtos.Api;
using DotNetBankingAppClientContracts.Enums;
using DotNetBankingAppClientContracts.Providers;
using System.Text.Json;
using System.Text;
using DotNetBankingAppClientContracts.Models;

namespace DotNetBankingAppClient.Providers
{
    public class MockApiProvider : IApiProvider
    {
        public async Task<BaseEndpointOutputDto<GetAccountsOperationOutput>> GetAccounts(GetAccountsOperationInput input)
        {
            return new BaseEndpointOutputDto<GetAccountsOperationOutput>
            {
                Data = new GetAccountsOperationOutput
                {
                    CheckingAccounts = new List<DotNetBankingAppClientContracts.Models.AccountDTO>
                    {
                        new DotNetBankingAppClientContracts.Models.AccountDTO
                        {
                            AccountId = "111111111111",
                            AccountName = "Checking Account",
                            AccountType = AccountType.Checking,
                            Balance = 1241.56,
                            Interest = 0,
                        }
                    },
                    SavingAccounts = new List<DotNetBankingAppClientContracts.Models.AccountDTO>
                    {
                        new DotNetBankingAppClientContracts.Models.AccountDTO
                        {
                            AccountId = "222222222222",
                            AccountName = "Emergency Funds",
                            AccountType = AccountType.Savings,
                            Balance = 100000,
                            Interest = 3.75,
                        },
                        new DotNetBankingAppClientContracts.Models.AccountDTO
                        {
                            AccountId = "333333333333",
                            AccountName = "College Savings",
                            AccountType = AccountType.Savings,
                            Balance = 60000,
                            Interest = 3.5,
                        }
                    },    
                },
                MetaData = new BaseEndpointOutputMetaData
                {
                    Success = true,
                    Message = string.Empty,
                }
            };
        }
        public async Task<BaseEndpointOutputDto<GetCardsOperationOutput>> GetCards(GetCardsOperationInput input)
        {
            return new BaseEndpointOutputDto<GetCardsOperationOutput>
            {
                Data = new GetCardsOperationOutput
                {
                    Cards = new List<DotNetBankingAppClientContracts.Models.CardDTO>
                    {
                        new CardDTO
                        {
                            CardNumber = "0000000000000000",
                            AccountId = "111111111111",
                            CardTier = CardTier.Classic,
                            CardType = CardType.Credit,
                            Embossing = "User One",
                        },
                        new CardDTO
                        {
                            CardNumber = "0000000000000001",
                            AccountId = "111111111111",
                            CardTier = CardTier.Premium,
                            CardType = CardType.Credit,
                            Embossing = "User One",
                        },
                        new CardDTO
                        {
                            CardNumber = "0000000000000002",
                            AccountId = "111111111111",
                            CardTier = CardTier.Carbon,
                            CardType = CardType.Credit,
                            Embossing = "User One",
                        },
                        new CardDTO
                        {
                            CardNumber = "0000000000000003",
                            AccountId = "111111111111",
                            CardTier = CardTier.Stellar,
                            CardType = CardType.Credit,
                            Embossing = "User One",
                        },
                        new CardDTO
                        {
                            CardNumber = "0000000000000004",
                            AccountId = "111111111111",
                            CardTier = CardTier.Classic,
                            CardType = CardType.Debit,
                            Embossing = "User One",
                        },
                        new CardDTO
                        {
                            CardNumber = "0000000000000005",
                            AccountId = "111111111111",
                            CardTier = CardTier.Premium,
                            CardType = CardType.Debit,
                            Embossing = "User One",
                        },
                        new CardDTO
                        {
                            CardNumber = "0000000000000006",
                            AccountId = "111111111111",
                            CardTier = CardTier.Carbon,
                            CardType = CardType.Debit,
                            Embossing = "User One",
                        },
                        new CardDTO
                        {
                            CardNumber = "0000000000000007",
                            AccountId = "111111111111",
                            CardTier = CardTier.Stellar,
                            CardType = CardType.Debit,
                            Embossing = "User One",
                        },
                        new CardDTO
                        {
                            CardNumber = "0000000000000008",
                            AccountId = "111111111111",
                            CardTier = CardTier.Classic,
                            CardType = CardType.PrePaid,
                            Embossing = "User One",
                        },
                        new CardDTO
                        {
                            CardNumber = "0000000000000009",
                            AccountId = "111111111111",
                            CardTier = CardTier.Premium,
                            CardType = CardType.PrePaid,
                            Embossing = "User One",
                        },
                        new CardDTO
                        {
                            CardNumber = "0000000000000010",
                            AccountId = "111111111111",
                            CardTier = CardTier.Carbon,
                            CardType = CardType.PrePaid,
                            Embossing = "User One",
                        },
                        new CardDTO
                        {
                            CardNumber = "0000000000000011",
                            AccountId = "111111111111",
                            CardTier = CardTier.Stellar,
                            CardType = CardType.PrePaid,
                            Embossing = "User One",
                        },
                    },
                },
                MetaData = new BaseEndpointOutputMetaData
                {
                    Success = true,
                    Message = string.Empty,
                }
            };
        }

        public async Task<BaseEndpointOutputDto<GetInboxOperationOutput>> GetInbox(GetInboxOperationInput input)
        {
            return new BaseEndpointOutputDto<GetInboxOperationOutput>
            {
                Data = new GetInboxOperationOutput
                {
                    GroupedMessages = new List<DotNetBankingAppClientContracts.Models.MessageDTOGroup>
                    {
                        new MessageDTOGroup
                        {
                            dateTime = new DateTime(2024, 04,11),
                            messages = new List<MessageDTO>
                            {
                                new MessageDTO
                                {
                                    Subject = "Money transfered successfully",
                                    Content = "You transfert to Contact1 was successfull",
                                    Date = new DateTime(2024, 04,11,19,07,59),
                                },
                                new MessageDTO
                                {
                                    Subject = "We were unable to send money",
                                    Content = "You attempt to send money to Contact1 failed. If you still want to transfer, please try again",
                                    Date = new DateTime(2024, 04,11,19,06,00),
                                },
                                new MessageDTO
                                {
                                    Subject = "New login detected",
                                    Content = "New login was detected on 19/04/2024 at 19:03",
                                    Date = new DateTime(2024, 04,11,19,04,00),
                                }
                            }
                        },
                        new MessageDTOGroup
                        {
                            dateTime = new DateTime(2024, 03,11),
                            messages = new List<MessageDTO>
                            {
                                new MessageDTO
                                {
                                    Subject = "Keep saving with us",
                                    Content = "Your saving earned you 472€ this year. Stick with us next year to improve your wealth.",
                                    Date = new DateTime(2024, 03,11,19,08,00),
                                }
                            }
                        },
                        new MessageDTOGroup
                        {
                            dateTime = new DateTime(2024, 02,11),
                            messages = new List<MessageDTO>
                            {
                                new MessageDTO
                                {
                                    Subject = "Your account has a new card",
                                    Content = "Card 1234 5678 9101 1121 was added to your acount",
                                    Date = new DateTime(2024, 02,11,19,10,00),
                                },
                                new MessageDTO
                                {
                                    Subject = "Welcome to DotNet Banking",
                                    Content = "Thank you for trying out this app!",
                                    Date = new DateTime(2024, 02,11,19,03,00),
                                }
                            }
                        },
                    },
                },
                MetaData = new BaseEndpointOutputMetaData
                {
                    Success = true,
                    Message = string.Empty,
                }
            };
        }

        public async Task<BaseEndpointOutputDto<GetTransactionsOperationOutput>> GetTransactions(GetTransactionsOperationInput input)
        {
            return new BaseEndpointOutputDto<GetTransactionsOperationOutput>
            {
                Data = new GetTransactionsOperationOutput
                {
                    Transactions = new List<DotNetBankingAppClientContracts.Models.TransactionDTO>
                    {
                        new TransactionDTO
                        {
                            Id = "0",
                            Amount = 42.19,
                            Description = "Internet",
                            Date = new DateTime(2024, 04, 29),
                            TransactionType = TransactionType.Debit,
                            Entity = "Meo Sa",
                            ReceiverAccount = "111111111111",
                            SenderAccount = string.Empty,
                            Comment = "",
                            BalanceBeforeTransaction = 1283.75,
                            BalanceAfterTransaction = 1241.56,
                            Method = null,
                            CardNumber = string.Empty,
                        },
                        new TransactionDTO
                        {
                            Id = "1",
                            Amount = 100,
                            Description = "CTT Withdrawal",
                            Date = new DateTime(2024, 04, 26),
                            TransactionType = TransactionType.Debit,
                            Entity = "Street 1 ATM",
                            ReceiverAccount = string.Empty,
                            SenderAccount = "111111111111",
                            Comment = "",
                            BalanceBeforeTransaction = 1283.75,
                            BalanceAfterTransaction = 1183.75,
                            Method = null,
                            CardNumber = "0000000000000000",
                        },
                        new TransactionDTO
                        {
                            Id = "2",
                            Amount = 44,
                            Description = "Amazon Shopping",
                            Date = new DateTime(2024, 04, 25),
                            TransactionType = TransactionType.Debit,
                            Entity = "Amazon",
                            ReceiverAccount = string.Empty,
                            SenderAccount = "111111111111",
                            Comment = "",
                            BalanceBeforeTransaction = 1183.75,
                            BalanceAfterTransaction = 1139.75,
                            Method = TransactionMethod.Card,
                            CardNumber = "0000000000000000",
                        },
                        new TransactionDTO
                        {
                            Id = "3",
                            Amount = 1000.02,
                            Description = "Monthly Savings",
                            Date = new DateTime(2024, 04, 25),
                            TransactionType = TransactionType.Debit,
                            Entity = "DotNet Bank",
                            ReceiverAccount = "333333333333",
                            SenderAccount = "111111111111",
                            Comment = "",
                            BalanceBeforeTransaction = 2183.77,
                            BalanceAfterTransaction = 1183.75,
                            Method = TransactionMethod.Homebanking,
                            CardNumber = string.Empty,
                        },
                        new TransactionDTO
                        {
                            Id = "4",
                            Amount = 1457,
                            Description = "Salary",
                            Date = new DateTime(2024, 04, 24),
                            TransactionType = TransactionType.Credit,
                            Entity = "Company 01",
                            ReceiverAccount = "111111111111",
                            SenderAccount = string.Empty,
                            Comment = "Employee 01",
                            BalanceBeforeTransaction = 725.77,
                            BalanceAfterTransaction = 2183.77,
                            Method = TransactionMethod.Homebanking,
                            CardNumber = string.Empty,
                        }
                    },
                },
                MetaData = new BaseEndpointOutputMetaData
                {
                    Success = true,
                    Message = string.Empty,
                }
            };
        }

        public async Task<BaseEndpointOutputDto<SignInOperationOutput>> SignIn(SignInOperationInput input)
        {
            return new BaseEndpointOutputDto<SignInOperationOutput>
            {
                Data = new SignInOperationOutput
                {
                    User = new DotNetBankingAppClientContracts.Models.UserDTO
                    {
                        UserName = "user1",
                        PhoneNumber = "911111111",
                    },
                    Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoidXNlcjEiLCJyb2xlIjoiY2xpZW50IiwibmJmIjoxNzE5NTY5NzExLCJleHAiOjE3MTk1NzMzMTEsImlhdCI6MTcxOTU2OTcxMX0.lXXALl4klZkXYXn1idcf5Ck8YskY6hxOuOX_RNuWpJk",
                },
                MetaData = new BaseEndpointOutputMetaData
                {
                    Success = true,
                    Message = string.Empty,
                }
            };
        }

    public async Task<BaseEndpointOutputDto<SignUpOperationOutput>> SignUp(SignUpOperationIntput input)
        {
            return new BaseEndpointOutputDto<SignUpOperationOutput>
            {
                Data = new SignUpOperationOutput
                {
                    User = new DotNetBankingAppClientContracts.Models.UserDTO
                    {
                        UserName = "user1",
                        PhoneNumber = "911111111",
                    },
                    Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoidXNlcjEiLCJyb2xlIjoiY2xpZW50IiwibmJmIjoxNzE5NTY5NzExLCJleHAiOjE3MTk1NzMzMTEsImlhdCI6MTcxOTU2OTcxMX0.lXXALl4klZkXYXn1idcf5Ck8YskY6hxOuOX_RNuWpJk",
                },
                MetaData = new BaseEndpointOutputMetaData
                {
                    Success = true,
                    Message = string.Empty,
                }
            };
        }
    }
}
