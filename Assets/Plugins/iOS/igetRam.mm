#import <mach/mach.h>
#import <mach/mach_host.h>

extern "C"
{

    const int igetRam(bool what)
    {
        mach_port_t host_port;
        mach_msg_type_number_t host_size;
        vm_size_t pagesize;

        host_port = mach_host_self();
        host_size = sizeof(vm_statistics_data_t) / sizeof(integer_t);
        host_page_size(host_port, &pagesize);

        vm_statistics_data_t vm_stat;

        if (host_statistics(host_port, HOST_VM_INFO, (host_info_t)&vm_stat, &host_size) != KERN_SUCCESS)
            return -1;

        natural_t used = (vm_stat.active_count + vm_stat.inactive_count + vm_stat.wire_count) * pagesize;
        
        natural_t free = vm_stat.free_count * pagesize;
        
       // natural_t total = used + free;

        if(what)
        return (int) free;
        else
        return (int) used;
    }

}