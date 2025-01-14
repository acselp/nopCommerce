﻿namespace Nop.Plugin.Payments.PayPalCommerce.PayPal.Checkout
{
    /// <summary>
    /// Represents the type of user action for customer checkout flow
    /// </summary>
    public enum UserActionType
    {
        /// <summary>
        /// After you redirect the customer to the PayPal payment page, a Continue button appears.
        /// </summary>
        Continue,

        /// <summary>
        /// After you redirect the customer to the PayPal payment page, a Pay Now button appears.
        /// </summary>
        Pay_now
    }
}