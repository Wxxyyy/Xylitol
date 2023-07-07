namespace Xy.Application.Admin;
public class SysUserMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // 映射到Input

        // 映射到OutPut

        // 映射到UserList
        config.ForType<SysUser,UserListOutput>()
            // 映射对象
            .Map(dest=> dest.userId ,src=>src.Uid)
            .Map(dest=> dest.userAccount ,src=>src.Account)
            .Map(dest=> dest.nickName ,src=>src.Nick)
            .Map(dest=> dest.userName ,src=>src.Name)
            .Map(dest=>dest.userGender,src=>src.Gender)
            .Map(dest=> dest.userPhone ,src=>src.Phone)
            .Map(dest=> dest.userEmail ,src=>src.Email)
            .Map(dest=> dest.userRemark ,src=>src.Remarks)
            .Map(dest=> dest.userStatus ,src=>src.Status)
            // 忽略
            //.Ignore(u => u.Password)
        ;
        

    }
}