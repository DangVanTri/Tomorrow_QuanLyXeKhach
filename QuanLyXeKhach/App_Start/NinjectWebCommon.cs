[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(QuanLyXeKhach.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(QuanLyXeKhach.App_Start.NinjectWebCommon), "Stop")]

namespace QuanLyXeKhach.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using DataService;
    using DataModel;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IPhongBanService<PhongBan>>().To<PhongBanService>();
            kernel.Bind<IChuyenXeService<ChuyenXe>>().To<ChuyenXeService>();
            kernel.Bind<ITuyenXeService<TuyenXe>>().To<TuyenXeService>();
            kernel.Bind<INhanVienService<NhanVien>>().To<NhanVienService>();
            kernel.Bind<IVaiTroService<VaiTro>>().To<VaiTroService>();
            kernel.Bind<ITrangThaiNVService<TrangThaiNV>>().To<TrangThaiNVService>();
            kernel.Bind<ITaiKhoanNVService<TaiKhoanNV>>().To<TaiKhoanNVService>();
            kernel.Bind<IKhachHangService<KhachHang>>().To<KhachHangService>();
            kernel.Bind<IDatVeService<DatVe>>().To<DatVeService>();
            kernel.Bind<IChiTietDatVeService<ChiTietDatVe>>().To<ChiTietDatVeService>();
            kernel.Bind<IThongKeService<ThongKe>>().To<ThongKeService>();
            kernel.Bind<IBaoCaoService<BaoCao>>().To<BaoCaoService>();
            kernel.Bind<IUngVienService<UngVien>>().To<UngVienService>();
            kernel.Bind<ITrangThaiUVService<TrangThaiUV>>().To<TrangThaiUVService>();
            kernel.Bind<ILichPhongVanService<LichPhongVan>>().To<LichPhongVanService>();
            kernel.Bind<ITramXeService<TramXe>>().To<TramXeService>();
            kernel.Bind<IHanhTrinhService<HanhTrinh>>().To<HanhTrinhService>();
            kernel.Bind<ICongViecService<CongViec>>().To<CongViecService>();
            kernel.Bind<IPhanCongService<PhanCong, NhanVien, CongViec>>().To<PhanCongService>();
            kernel.Bind<IBangChamCongService<BangChamCong>>().To<BangChamCongService>();
        }
    }
}
