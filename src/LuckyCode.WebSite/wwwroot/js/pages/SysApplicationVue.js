var vm = new Vue({
    el: "#applicationApp",
    data: {
        applications: [],
        totalItems: 0,
        currentPageIndex: 1,
        pageSize: 2,
        totalRowCount: 0
    },
    created:function() {
        this.initTable();
    },
    filters: {
        dateFormat: function(value, format) {
            if (value) {
                return moment(value).format(format);
            }
            return '';
        }
    },
    methods: {
        initTable:function() {
            var self = this;
            var params={
                pageIndex: self.currentPageIndex,
                pageSize: self.pageSize,
                _: Date.parse(new Date())
            }
            axios.get('GetListViewModel', { params: params }).then(function (res) {
                console.log(res);
                self.applications = res.data.rows;
                self.totalRowCount = res.data.total;
            }).catch((res) => {

            });
        },
        pageChange:function(pageIndex) {
            this.currentPageIndex = pageIndex;
            this.initTable();
        }
    }
});