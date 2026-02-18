using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAPClient
{
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    //public interface NetSuitePortTypeChannel : NetSuitePortType, System.ServiceModel.IClientChannel
    //{
    //}

    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    //public partial class NetSuitePortTypeClient : System.ServiceModel.ClientBase<NetSuitePortType>, NetSuitePortType
    //{

    //    public NetSuitePortTypeClient()
    //    {
    //    }

    //    public NetSuitePortTypeClient(string endpointConfigurationName) : 
    //            base(endpointConfigurationName)
    //    {
    //    }

    //    public NetSuitePortTypeClient(string endpointConfigurationName, string remoteAddress) : 
    //            base(endpointConfigurationName, remoteAddress)
    //    {
    //    }

    //    public NetSuitePortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
    //            base(endpointConfigurationName, remoteAddress)
    //    {
    //    }

    //    public NetSuitePortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
    //            base(binding, remoteAddress)
    //    {
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    changePasswordResponse NetSuitePortType.changePassword(changePasswordRequest request)
    //    {
    //        return base.Channel.changePassword(request);
    //    }

    //    public SessionResponse changePassword(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, ChangePassword changePassword1)
    //    {
    //        changePasswordRequest inValue = new changePasswordRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.changePassword = changePassword1;
    //        changePasswordResponse retVal = ((NetSuitePortType)(this)).changePassword(inValue);
    //        return retVal.sessionResponse;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<changePasswordResponse> NetSuitePortType.changePasswordAsync(changePasswordRequest request)
    //    {
    //        return base.Channel.changePasswordAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<changePasswordResponse> changePasswordAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, ChangePassword changePassword)
    //    {
    //        changePasswordRequest inValue = new changePasswordRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.changePassword = changePassword;
    //        return ((NetSuitePortType)(this)).changePasswordAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    changeEmailResponse NetSuitePortType.changeEmail(changeEmailRequest request)
    //    {
    //        return base.Channel.changeEmail(request);
    //    }

    //    public SessionResponse changeEmail(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, ChangeEmail changeEmail1)
    //    {
    //        changeEmailRequest inValue = new changeEmailRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.changeEmail = changeEmail1;
    //        changeEmailResponse retVal = ((NetSuitePortType)(this)).changeEmail(inValue);
    //        return retVal.sessionResponse;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<changeEmailResponse> NetSuitePortType.changeEmailAsync(changeEmailRequest request)
    //    {
    //        return base.Channel.changeEmailAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<changeEmailResponse> changeEmailAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, ChangeEmail changeEmail)
    //    {
    //        changeEmailRequest inValue = new changeEmailRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.changeEmail = changeEmail;
    //        return ((NetSuitePortType)(this)).changeEmailAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    addResponse NetSuitePortType.add(addRequest request)
    //    {
    //        return base.Channel.add(request);
    //    }

    //    public DocumentInfo add(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record record, out WriteResponse writeResponse)
    //    {
    //        addRequest inValue = new addRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        addResponse retVal = ((NetSuitePortType)(this)).add(inValue);
    //        writeResponse = retVal.writeResponse;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<addResponse> NetSuitePortType.addAsync(addRequest request)
    //    {
    //        return base.Channel.addAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<addResponse> addAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record record)
    //    {
    //        addRequest inValue = new addRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        return ((NetSuitePortType)(this)).addAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    deleteResponse NetSuitePortType.delete(deleteRequest request)
    //    {
    //        return base.Channel.delete(request);
    //    }

    //    public DocumentInfo delete(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BaseRef baseRef, DeletionReason deletionReason, out WriteResponse writeResponse)
    //    {
    //        deleteRequest inValue = new deleteRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.baseRef = baseRef;
    //        inValue.deletionReason = deletionReason;
    //        deleteResponse retVal = ((NetSuitePortType)(this)).delete(inValue);
    //        writeResponse = retVal.writeResponse;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<deleteResponse> NetSuitePortType.deleteAsync(deleteRequest request)
    //    {
    //        return base.Channel.deleteAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<deleteResponse> deleteAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BaseRef baseRef, DeletionReason deletionReason)
    //    {
    //        deleteRequest inValue = new deleteRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.baseRef = baseRef;
    //        inValue.deletionReason = deletionReason;
    //        return ((NetSuitePortType)(this)).deleteAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    searchResponse NetSuitePortType.search(searchRequest request)
    //    {
    //        return base.Channel.search(request);
    //    }

    //    public DocumentInfo search(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, SearchPreferences searchPreferences, SearchRecord searchRecord, out SearchResult searchResult)
    //    {
    //        searchRequest inValue = new searchRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.searchPreferences = searchPreferences;
    //        inValue.searchRecord = searchRecord;
    //        searchResponse retVal = ((NetSuitePortType)(this)).search(inValue);
    //        searchResult = retVal.searchResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<searchResponse> NetSuitePortType.searchAsync(searchRequest request)
    //    {
    //        return base.Channel.searchAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<searchResponse> searchAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, SearchPreferences searchPreferences, SearchRecord searchRecord)
    //    {
    //        searchRequest inValue = new searchRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.searchPreferences = searchPreferences;
    //        inValue.searchRecord = searchRecord;
    //        return ((NetSuitePortType)(this)).searchAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    searchMoreWithIdResponse NetSuitePortType.searchMoreWithId(searchMoreWithIdRequest request)
    //    {
    //        return base.Channel.searchMoreWithId(request);
    //    }

    //    public DocumentInfo searchMoreWithId(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, SearchPreferences searchPreferences, string searchId, int pageIndex, out SearchResult searchResult)
    //    {
    //        searchMoreWithIdRequest inValue = new searchMoreWithIdRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.searchPreferences = searchPreferences;
    //        inValue.searchId = searchId;
    //        inValue.pageIndex = pageIndex;
    //        searchMoreWithIdResponse retVal = ((NetSuitePortType)(this)).searchMoreWithId(inValue);
    //        searchResult = retVal.searchResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<searchMoreWithIdResponse> NetSuitePortType.searchMoreWithIdAsync(searchMoreWithIdRequest request)
    //    {
    //        return base.Channel.searchMoreWithIdAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<searchMoreWithIdResponse> searchMoreWithIdAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, SearchPreferences searchPreferences, string searchId, int pageIndex)
    //    {
    //        searchMoreWithIdRequest inValue = new searchMoreWithIdRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.searchPreferences = searchPreferences;
    //        inValue.searchId = searchId;
    //        inValue.pageIndex = pageIndex;
    //        return ((NetSuitePortType)(this)).searchMoreWithIdAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    updateResponse NetSuitePortType.update(updateRequest request)
    //    {
    //        return base.Channel.update(request);
    //    }

    //    public DocumentInfo update(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record record, out WriteResponse writeResponse)
    //    {
    //        updateRequest inValue = new updateRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        updateResponse retVal = ((NetSuitePortType)(this)).update(inValue);
    //        writeResponse = retVal.writeResponse;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<updateResponse> NetSuitePortType.updateAsync(updateRequest request)
    //    {
    //        return base.Channel.updateAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<updateResponse> updateAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record record)
    //    {
    //        updateRequest inValue = new updateRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        return ((NetSuitePortType)(this)).updateAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    upsertResponse NetSuitePortType.upsert(upsertRequest request)
    //    {
    //        return base.Channel.upsert(request);
    //    }

    //    public DocumentInfo upsert(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record record, out WriteResponse writeResponse)
    //    {
    //        upsertRequest inValue = new upsertRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        upsertResponse retVal = ((NetSuitePortType)(this)).upsert(inValue);
    //        writeResponse = retVal.writeResponse;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<upsertResponse> NetSuitePortType.upsertAsync(upsertRequest request)
    //    {
    //        return base.Channel.upsertAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<upsertResponse> upsertAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record record)
    //    {
    //        upsertRequest inValue = new upsertRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        return ((NetSuitePortType)(this)).upsertAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    addListResponse NetSuitePortType.addList(addListRequest request)
    //    {
    //        return base.Channel.addList(request);
    //    }

    //    public DocumentInfo addList(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record[] record, out WriteResponseList writeResponseList)
    //    {
    //        addListRequest inValue = new addListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        addListResponse retVal = ((NetSuitePortType)(this)).addList(inValue);
    //        writeResponseList = retVal.writeResponseList;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<addListResponse> NetSuitePortType.addListAsync(addListRequest request)
    //    {
    //        return base.Channel.addListAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<addListResponse> addListAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record[] record)
    //    {
    //        addListRequest inValue = new addListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        return ((NetSuitePortType)(this)).addListAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    deleteListResponse NetSuitePortType.deleteList(deleteListRequest request)
    //    {
    //        return base.Channel.deleteList(request);
    //    }

    //    public DocumentInfo deleteList(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BaseRef[] baseRef, DeletionReason deletionReason, out WriteResponseList writeResponseList)
    //    {
    //        deleteListRequest inValue = new deleteListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.baseRef = baseRef;
    //        inValue.deletionReason = deletionReason;
    //        deleteListResponse retVal = ((NetSuitePortType)(this)).deleteList(inValue);
    //        writeResponseList = retVal.writeResponseList;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<deleteListResponse> NetSuitePortType.deleteListAsync(deleteListRequest request)
    //    {
    //        return base.Channel.deleteListAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<deleteListResponse> deleteListAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BaseRef[] baseRef, DeletionReason deletionReason)
    //    {
    //        deleteListRequest inValue = new deleteListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.baseRef = baseRef;
    //        inValue.deletionReason = deletionReason;
    //        return ((NetSuitePortType)(this)).deleteListAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    updateListResponse NetSuitePortType.updateList(updateListRequest request)
    //    {
    //        return base.Channel.updateList(request);
    //    }

    //    public DocumentInfo updateList(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record[] record, out WriteResponseList writeResponseList)
    //    {
    //        updateListRequest inValue = new updateListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        updateListResponse retVal = ((NetSuitePortType)(this)).updateList(inValue);
    //        writeResponseList = retVal.writeResponseList;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<updateListResponse> NetSuitePortType.updateListAsync(updateListRequest request)
    //    {
    //        return base.Channel.updateListAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<updateListResponse> updateListAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record[] record)
    //    {
    //        updateListRequest inValue = new updateListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        return ((NetSuitePortType)(this)).updateListAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    upsertListResponse NetSuitePortType.upsertList(upsertListRequest request)
    //    {
    //        return base.Channel.upsertList(request);
    //    }

    //    public DocumentInfo upsertList(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record[] record, out WriteResponseList writeResponseList)
    //    {
    //        upsertListRequest inValue = new upsertListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        upsertListResponse retVal = ((NetSuitePortType)(this)).upsertList(inValue);
    //        writeResponseList = retVal.writeResponseList;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<upsertListResponse> NetSuitePortType.upsertListAsync(upsertListRequest request)
    //    {
    //        return base.Channel.upsertListAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<upsertListResponse> upsertListAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record[] record)
    //    {
    //        upsertListRequest inValue = new upsertListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        return ((NetSuitePortType)(this)).upsertListAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getResponse NetSuitePortType.get(getRequest request)
    //    {
    //        return base.Channel.get(request);
    //    }

    //    public DocumentInfo get(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BaseRef baseRef, out ReadResponse readResponse)
    //    {
    //        getRequest inValue = new getRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.baseRef = baseRef;
    //        getResponse retVal = ((NetSuitePortType)(this)).get(inValue);
    //        readResponse = retVal.readResponse;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getResponse> NetSuitePortType.getAsync(getRequest request)
    //    {
    //        return base.Channel.getAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getResponse> getAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BaseRef baseRef)
    //    {
    //        getRequest inValue = new getRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.baseRef = baseRef;
    //        return ((NetSuitePortType)(this)).getAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getListResponse NetSuitePortType.getList(getListRequest request)
    //    {
    //        return base.Channel.getList(request);
    //    }

    //    public DocumentInfo getList(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BaseRef[] baseRef, out ReadResponseList readResponseList)
    //    {
    //        getListRequest inValue = new getListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.baseRef = baseRef;
    //        getListResponse retVal = ((NetSuitePortType)(this)).getList(inValue);
    //        readResponseList = retVal.readResponseList;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getListResponse> NetSuitePortType.getListAsync(getListRequest request)
    //    {
    //        return base.Channel.getListAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getListResponse> getListAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BaseRef[] baseRef)
    //    {
    //        getListRequest inValue = new getListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.baseRef = baseRef;
    //        return ((NetSuitePortType)(this)).getListAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getAllResponse NetSuitePortType.getAll(getAllRequest request)
    //    {
    //        return base.Channel.getAll(request);
    //    }

    //    public DocumentInfo getAll(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, GetAllRecord record, out GetAllResult getAllResult)
    //    {
    //        getAllRequest inValue = new getAllRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        getAllResponse retVal = ((NetSuitePortType)(this)).getAll(inValue);
    //        getAllResult = retVal.getAllResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getAllResponse> NetSuitePortType.getAllAsync(getAllRequest request)
    //    {
    //        return base.Channel.getAllAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getAllResponse> getAllAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, GetAllRecord record)
    //    {
    //        getAllRequest inValue = new getAllRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        return ((NetSuitePortType)(this)).getAllAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getSavedSearchResponse NetSuitePortType.getSavedSearch(getSavedSearchRequest request)
    //    {
    //        return base.Channel.getSavedSearch(request);
    //    }

    //    public DocumentInfo getSavedSearch(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, GetSavedSearchRecord record, out GetSavedSearchResult getSavedSearchResult)
    //    {
    //        getSavedSearchRequest inValue = new getSavedSearchRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        getSavedSearchResponse retVal = ((NetSuitePortType)(this)).getSavedSearch(inValue);
    //        getSavedSearchResult = retVal.getSavedSearchResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getSavedSearchResponse> NetSuitePortType.getSavedSearchAsync(getSavedSearchRequest request)
    //    {
    //        return base.Channel.getSavedSearchAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getSavedSearchResponse> getSavedSearchAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, GetSavedSearchRecord record)
    //    {
    //        getSavedSearchRequest inValue = new getSavedSearchRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        return ((NetSuitePortType)(this)).getSavedSearchAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getCustomizationIdResponse NetSuitePortType.getCustomizationId(getCustomizationIdRequest request)
    //    {
    //        return base.Channel.getCustomizationId(request);
    //    }

    //    public DocumentInfo getCustomizationId(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, CustomizationType customizationType, bool includeInactives, out GetCustomizationIdResult getCustomizationIdResult)
    //    {
    //        getCustomizationIdRequest inValue = new getCustomizationIdRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.customizationType = customizationType;
    //        inValue.includeInactives = includeInactives;
    //        getCustomizationIdResponse retVal = ((NetSuitePortType)(this)).getCustomizationId(inValue);
    //        getCustomizationIdResult = retVal.getCustomizationIdResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getCustomizationIdResponse> NetSuitePortType.getCustomizationIdAsync(getCustomizationIdRequest request)
    //    {
    //        return base.Channel.getCustomizationIdAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getCustomizationIdResponse> getCustomizationIdAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, CustomizationType customizationType, bool includeInactives)
    //    {
    //        getCustomizationIdRequest inValue = new getCustomizationIdRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.customizationType = customizationType;
    //        inValue.includeInactives = includeInactives;
    //        return ((NetSuitePortType)(this)).getCustomizationIdAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    initializeResponse NetSuitePortType.initialize(initializeRequest request)
    //    {
    //        return base.Channel.initialize(request);
    //    }

    //    public DocumentInfo initialize(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, InitializeRecord initializeRecord, out ReadResponse readResponse)
    //    {
    //        initializeRequest inValue = new initializeRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.initializeRecord = initializeRecord;
    //        initializeResponse retVal = ((NetSuitePortType)(this)).initialize(inValue);
    //        readResponse = retVal.readResponse;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<initializeResponse> NetSuitePortType.initializeAsync(initializeRequest request)
    //    {
    //        return base.Channel.initializeAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<initializeResponse> initializeAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, InitializeRecord initializeRecord)
    //    {
    //        initializeRequest inValue = new initializeRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.initializeRecord = initializeRecord;
    //        return ((NetSuitePortType)(this)).initializeAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    initializeListResponse NetSuitePortType.initializeList(initializeListRequest request)
    //    {
    //        return base.Channel.initializeList(request);
    //    }

    //    public DocumentInfo initializeList(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, InitializeRecord[] initializeRecord, out ReadResponseList readResponseList)
    //    {
    //        initializeListRequest inValue = new initializeListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.initializeRecord = initializeRecord;
    //        initializeListResponse retVal = ((NetSuitePortType)(this)).initializeList(inValue);
    //        readResponseList = retVal.readResponseList;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<initializeListResponse> NetSuitePortType.initializeListAsync(initializeListRequest request)
    //    {
    //        return base.Channel.initializeListAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<initializeListResponse> initializeListAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, InitializeRecord[] initializeRecord)
    //    {
    //        initializeListRequest inValue = new initializeListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.initializeRecord = initializeRecord;
    //        return ((NetSuitePortType)(this)).initializeListAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getSelectValueResponse NetSuitePortType.getSelectValue(getSelectValueRequest request)
    //    {
    //        return base.Channel.getSelectValue(request);
    //    }

    //    public DocumentInfo getSelectValue(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, GetSelectValueFieldDescription fieldDescription, int pageIndex, out GetSelectValueResult getSelectValueResult)
    //    {
    //        getSelectValueRequest inValue = new getSelectValueRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.fieldDescription = fieldDescription;
    //        inValue.pageIndex = pageIndex;
    //        getSelectValueResponse retVal = ((NetSuitePortType)(this)).getSelectValue(inValue);
    //        getSelectValueResult = retVal.getSelectValueResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getSelectValueResponse> NetSuitePortType.getSelectValueAsync(getSelectValueRequest request)
    //    {
    //        return base.Channel.getSelectValueAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getSelectValueResponse> getSelectValueAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, GetSelectValueFieldDescription fieldDescription, int pageIndex)
    //    {
    //        getSelectValueRequest inValue = new getSelectValueRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.fieldDescription = fieldDescription;
    //        inValue.pageIndex = pageIndex;
    //        return ((NetSuitePortType)(this)).getSelectValueAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getItemAvailabilityResponse NetSuitePortType.getItemAvailability(getItemAvailabilityRequest request)
    //    {
    //        return base.Channel.getItemAvailability(request);
    //    }

    //    public DocumentInfo getItemAvailability(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, ItemAvailabilityFilter itemAvailabilityFilter, out GetItemAvailabilityResult getItemAvailabilityResult)
    //    {
    //        getItemAvailabilityRequest inValue = new getItemAvailabilityRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.itemAvailabilityFilter = itemAvailabilityFilter;
    //        getItemAvailabilityResponse retVal = ((NetSuitePortType)(this)).getItemAvailability(inValue);
    //        getItemAvailabilityResult = retVal.getItemAvailabilityResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getItemAvailabilityResponse> NetSuitePortType.getItemAvailabilityAsync(getItemAvailabilityRequest request)
    //    {
    //        return base.Channel.getItemAvailabilityAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getItemAvailabilityResponse> getItemAvailabilityAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, ItemAvailabilityFilter itemAvailabilityFilter)
    //    {
    //        getItemAvailabilityRequest inValue = new getItemAvailabilityRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.itemAvailabilityFilter = itemAvailabilityFilter;
    //        return ((NetSuitePortType)(this)).getItemAvailabilityAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getBudgetExchangeRateResponse NetSuitePortType.getBudgetExchangeRate(getBudgetExchangeRateRequest request)
    //    {
    //        return base.Channel.getBudgetExchangeRate(request);
    //    }

    //    public DocumentInfo getBudgetExchangeRate(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BudgetExchangeRateFilter budgetExchangeRateFilter, out GetBudgetExchangeRateResult getBudgetExchangeRateResult)
    //    {
    //        getBudgetExchangeRateRequest inValue = new getBudgetExchangeRateRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.budgetExchangeRateFilter = budgetExchangeRateFilter;
    //        getBudgetExchangeRateResponse retVal = ((NetSuitePortType)(this)).getBudgetExchangeRate(inValue);
    //        getBudgetExchangeRateResult = retVal.getBudgetExchangeRateResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getBudgetExchangeRateResponse> NetSuitePortType.getBudgetExchangeRateAsync(getBudgetExchangeRateRequest request)
    //    {
    //        return base.Channel.getBudgetExchangeRateAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getBudgetExchangeRateResponse> getBudgetExchangeRateAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BudgetExchangeRateFilter budgetExchangeRateFilter)
    //    {
    //        getBudgetExchangeRateRequest inValue = new getBudgetExchangeRateRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.budgetExchangeRateFilter = budgetExchangeRateFilter;
    //        return ((NetSuitePortType)(this)).getBudgetExchangeRateAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getCurrencyRateResponse NetSuitePortType.getCurrencyRate(getCurrencyRateRequest request)
    //    {
    //        return base.Channel.getCurrencyRate(request);
    //    }

    //    public DocumentInfo getCurrencyRate(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, CurrencyRateFilter currencyRateFilter, out GetCurrencyRateResult getCurrencyRateResult)
    //    {
    //        getCurrencyRateRequest inValue = new getCurrencyRateRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.currencyRateFilter = currencyRateFilter;
    //        getCurrencyRateResponse retVal = ((NetSuitePortType)(this)).getCurrencyRate(inValue);
    //        getCurrencyRateResult = retVal.getCurrencyRateResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getCurrencyRateResponse> NetSuitePortType.getCurrencyRateAsync(getCurrencyRateRequest request)
    //    {
    //        return base.Channel.getCurrencyRateAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getCurrencyRateResponse> getCurrencyRateAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, CurrencyRateFilter currencyRateFilter)
    //    {
    //        getCurrencyRateRequest inValue = new getCurrencyRateRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.currencyRateFilter = currencyRateFilter;
    //        return ((NetSuitePortType)(this)).getCurrencyRateAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getDataCenterUrlsResponse NetSuitePortType.getDataCenterUrls(getDataCenterUrlsRequest request)
    //    {
    //        return base.Channel.getDataCenterUrls(request);
    //    }

    //    public DocumentInfo getDataCenterUrls(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, string account, out GetDataCenterUrlsResult getDataCenterUrlsResult)
    //    {
    //        getDataCenterUrlsRequest inValue = new getDataCenterUrlsRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.account = account;
    //        getDataCenterUrlsResponse retVal = ((NetSuitePortType)(this)).getDataCenterUrls(inValue);
    //        getDataCenterUrlsResult = retVal.getDataCenterUrlsResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getDataCenterUrlsResponse> NetSuitePortType.getDataCenterUrlsAsync(getDataCenterUrlsRequest request)
    //    {
    //        return base.Channel.getDataCenterUrlsAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getDataCenterUrlsResponse> getDataCenterUrlsAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, string account)
    //    {
    //        getDataCenterUrlsRequest inValue = new getDataCenterUrlsRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.account = account;
    //        return ((NetSuitePortType)(this)).getDataCenterUrlsAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getPostingTransactionSummaryResponse NetSuitePortType.getPostingTransactionSummary(getPostingTransactionSummaryRequest request)
    //    {
    //        return base.Channel.getPostingTransactionSummary(request);
    //    }

    //    public DocumentInfo getPostingTransactionSummary(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, PostingTransactionSummaryField fields, PostingTransactionSummaryFilter filters, int pageIndex, string operationId, out GetPostingTransactionSummaryResult getPostingTransactionSummaryResult)
    //    {
    //        getPostingTransactionSummaryRequest inValue = new getPostingTransactionSummaryRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.fields = fields;
    //        inValue.filters = filters;
    //        inValue.pageIndex = pageIndex;
    //        inValue.operationId = operationId;
    //        getPostingTransactionSummaryResponse retVal = ((NetSuitePortType)(this)).getPostingTransactionSummary(inValue);
    //        getPostingTransactionSummaryResult = retVal.getPostingTransactionSummaryResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getPostingTransactionSummaryResponse> NetSuitePortType.getPostingTransactionSummaryAsync(getPostingTransactionSummaryRequest request)
    //    {
    //        return base.Channel.getPostingTransactionSummaryAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getPostingTransactionSummaryResponse> getPostingTransactionSummaryAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, PostingTransactionSummaryField fields, PostingTransactionSummaryFilter filters, int pageIndex, string operationId)
    //    {
    //        getPostingTransactionSummaryRequest inValue = new getPostingTransactionSummaryRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.fields = fields;
    //        inValue.filters = filters;
    //        inValue.pageIndex = pageIndex;
    //        inValue.operationId = operationId;
    //        return ((NetSuitePortType)(this)).getPostingTransactionSummaryAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getServerTimeResponse NetSuitePortType.getServerTime(getServerTimeRequest request)
    //    {
    //        return base.Channel.getServerTime(request);
    //    }

    //    public DocumentInfo getServerTime(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, out GetServerTimeResult getServerTimeResult)
    //    {
    //        getServerTimeRequest inValue = new getServerTimeRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        getServerTimeResponse retVal = ((NetSuitePortType)(this)).getServerTime(inValue);
    //        getServerTimeResult = retVal.getServerTimeResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getServerTimeResponse> NetSuitePortType.getServerTimeAsync(getServerTimeRequest request)
    //    {
    //        return base.Channel.getServerTimeAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getServerTimeResponse> getServerTimeAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo)
    //    {
    //        getServerTimeRequest inValue = new getServerTimeRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        return ((NetSuitePortType)(this)).getServerTimeAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    attachResponse NetSuitePortType.attach(attachRequest request)
    //    {
    //        return base.Channel.attach(request);
    //    }

    //    public DocumentInfo attach(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, AttachReference attachReference, out WriteResponse writeResponse)
    //    {
    //        attachRequest inValue = new attachRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.attachReference = attachReference;
    //        attachResponse retVal = ((NetSuitePortType)(this)).attach(inValue);
    //        writeResponse = retVal.writeResponse;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<attachResponse> NetSuitePortType.attachAsync(attachRequest request)
    //    {
    //        return base.Channel.attachAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<attachResponse> attachAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, AttachReference attachReference)
    //    {
    //        attachRequest inValue = new attachRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.attachReference = attachReference;
    //        return ((NetSuitePortType)(this)).attachAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    detachResponse NetSuitePortType.detach(detachRequest request)
    //    {
    //        return base.Channel.detach(request);
    //    }

    //    public DocumentInfo detach(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, DetachReference detachReference, out WriteResponse writeResponse)
    //    {
    //        detachRequest inValue = new detachRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.detachReference = detachReference;
    //        detachResponse retVal = ((NetSuitePortType)(this)).detach(inValue);
    //        writeResponse = retVal.writeResponse;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<detachResponse> NetSuitePortType.detachAsync(detachRequest request)
    //    {
    //        return base.Channel.detachAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<detachResponse> detachAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, DetachReference detachReference)
    //    {
    //        detachRequest inValue = new detachRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.detachReference = detachReference;
    //        return ((NetSuitePortType)(this)).detachAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    updateInviteeStatusResponse NetSuitePortType.updateInviteeStatus(updateInviteeStatusRequest request)
    //    {
    //        return base.Channel.updateInviteeStatus(request);
    //    }

    //    public DocumentInfo updateInviteeStatus(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, UpdateInviteeStatusReference updateInviteeStatusReference, out WriteResponse writeResponse)
    //    {
    //        updateInviteeStatusRequest inValue = new updateInviteeStatusRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.updateInviteeStatusReference = updateInviteeStatusReference;
    //        updateInviteeStatusResponse retVal = ((NetSuitePortType)(this)).updateInviteeStatus(inValue);
    //        writeResponse = retVal.writeResponse;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<updateInviteeStatusResponse> NetSuitePortType.updateInviteeStatusAsync(updateInviteeStatusRequest request)
    //    {
    //        return base.Channel.updateInviteeStatusAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<updateInviteeStatusResponse> updateInviteeStatusAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, UpdateInviteeStatusReference updateInviteeStatusReference)
    //    {
    //        updateInviteeStatusRequest inValue = new updateInviteeStatusRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.updateInviteeStatusReference = updateInviteeStatusReference;
    //        return ((NetSuitePortType)(this)).updateInviteeStatusAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    updateInviteeStatusListResponse NetSuitePortType.updateInviteeStatusList(updateInviteeStatusListRequest request)
    //    {
    //        return base.Channel.updateInviteeStatusList(request);
    //    }

    //    public DocumentInfo updateInviteeStatusList(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, UpdateInviteeStatusReference[] updateInviteeStatusReference, out WriteResponseList writeResponseList)
    //    {
    //        updateInviteeStatusListRequest inValue = new updateInviteeStatusListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.updateInviteeStatusReference = updateInviteeStatusReference;
    //        updateInviteeStatusListResponse retVal = ((NetSuitePortType)(this)).updateInviteeStatusList(inValue);
    //        writeResponseList = retVal.writeResponseList;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<updateInviteeStatusListResponse> NetSuitePortType.updateInviteeStatusListAsync(updateInviteeStatusListRequest request)
    //    {
    //        return base.Channel.updateInviteeStatusListAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<updateInviteeStatusListResponse> updateInviteeStatusListAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, UpdateInviteeStatusReference[] updateInviteeStatusReference)
    //    {
    //        updateInviteeStatusListRequest inValue = new updateInviteeStatusListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.updateInviteeStatusReference = updateInviteeStatusReference;
    //        return ((NetSuitePortType)(this)).updateInviteeStatusListAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    asyncAddListResponse NetSuitePortType.asyncAddList(asyncAddListRequest request)
    //    {
    //        return base.Channel.asyncAddList(request);
    //    }

    //    public DocumentInfo asyncAddList(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record[] record, out AsyncStatusResult asyncStatusResult)
    //    {
    //        asyncAddListRequest inValue = new asyncAddListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        asyncAddListResponse retVal = ((NetSuitePortType)(this)).asyncAddList(inValue);
    //        asyncStatusResult = retVal.asyncStatusResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<asyncAddListResponse> NetSuitePortType.asyncAddListAsync(asyncAddListRequest request)
    //    {
    //        return base.Channel.asyncAddListAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<asyncAddListResponse> asyncAddListAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record[] record)
    //    {
    //        asyncAddListRequest inValue = new asyncAddListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        return ((NetSuitePortType)(this)).asyncAddListAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    asyncUpdateListResponse NetSuitePortType.asyncUpdateList(asyncUpdateListRequest request)
    //    {
    //        return base.Channel.asyncUpdateList(request);
    //    }

    //    public DocumentInfo asyncUpdateList(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record[] record, out AsyncStatusResult asyncStatusResult)
    //    {
    //        asyncUpdateListRequest inValue = new asyncUpdateListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        asyncUpdateListResponse retVal = ((NetSuitePortType)(this)).asyncUpdateList(inValue);
    //        asyncStatusResult = retVal.asyncStatusResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<asyncUpdateListResponse> NetSuitePortType.asyncUpdateListAsync(asyncUpdateListRequest request)
    //    {
    //        return base.Channel.asyncUpdateListAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<asyncUpdateListResponse> asyncUpdateListAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record[] record)
    //    {
    //        asyncUpdateListRequest inValue = new asyncUpdateListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        return ((NetSuitePortType)(this)).asyncUpdateListAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    asyncUpsertListResponse NetSuitePortType.asyncUpsertList(asyncUpsertListRequest request)
    //    {
    //        return base.Channel.asyncUpsertList(request);
    //    }

    //    public DocumentInfo asyncUpsertList(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record[] record, out AsyncStatusResult asyncStatusResult)
    //    {
    //        asyncUpsertListRequest inValue = new asyncUpsertListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        asyncUpsertListResponse retVal = ((NetSuitePortType)(this)).asyncUpsertList(inValue);
    //        asyncStatusResult = retVal.asyncStatusResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<asyncUpsertListResponse> NetSuitePortType.asyncUpsertListAsync(asyncUpsertListRequest request)
    //    {
    //        return base.Channel.asyncUpsertListAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<asyncUpsertListResponse> asyncUpsertListAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, Record[] record)
    //    {
    //        asyncUpsertListRequest inValue = new asyncUpsertListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.record = record;
    //        return ((NetSuitePortType)(this)).asyncUpsertListAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    asyncDeleteListResponse NetSuitePortType.asyncDeleteList(asyncDeleteListRequest request)
    //    {
    //        return base.Channel.asyncDeleteList(request);
    //    }

    //    public DocumentInfo asyncDeleteList(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BaseRef[] baseRef, DeletionReason deletionReason, out AsyncStatusResult asyncStatusResult)
    //    {
    //        asyncDeleteListRequest inValue = new asyncDeleteListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.baseRef = baseRef;
    //        inValue.deletionReason = deletionReason;
    //        asyncDeleteListResponse retVal = ((NetSuitePortType)(this)).asyncDeleteList(inValue);
    //        asyncStatusResult = retVal.asyncStatusResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<asyncDeleteListResponse> NetSuitePortType.asyncDeleteListAsync(asyncDeleteListRequest request)
    //    {
    //        return base.Channel.asyncDeleteListAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<asyncDeleteListResponse> asyncDeleteListAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BaseRef[] baseRef, DeletionReason deletionReason)
    //    {
    //        asyncDeleteListRequest inValue = new asyncDeleteListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.baseRef = baseRef;
    //        inValue.deletionReason = deletionReason;
    //        return ((NetSuitePortType)(this)).asyncDeleteListAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    asyncGetListResponse NetSuitePortType.asyncGetList(asyncGetListRequest request)
    //    {
    //        return base.Channel.asyncGetList(request);
    //    }

    //    public DocumentInfo asyncGetList(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BaseRef[] baseRef, out AsyncStatusResult asyncStatusResult)
    //    {
    //        asyncGetListRequest inValue = new asyncGetListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.baseRef = baseRef;
    //        asyncGetListResponse retVal = ((NetSuitePortType)(this)).asyncGetList(inValue);
    //        asyncStatusResult = retVal.asyncStatusResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<asyncGetListResponse> NetSuitePortType.asyncGetListAsync(asyncGetListRequest request)
    //    {
    //        return base.Channel.asyncGetListAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<asyncGetListResponse> asyncGetListAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, BaseRef[] baseRef)
    //    {
    //        asyncGetListRequest inValue = new asyncGetListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.baseRef = baseRef;
    //        return ((NetSuitePortType)(this)).asyncGetListAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    asyncInitializeListResponse NetSuitePortType.asyncInitializeList(asyncInitializeListRequest request)
    //    {
    //        return base.Channel.asyncInitializeList(request);
    //    }

    //    public DocumentInfo asyncInitializeList(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, InitializeRecord[] initializeRecord, out AsyncStatusResult asyncStatusResult)
    //    {
    //        asyncInitializeListRequest inValue = new asyncInitializeListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.initializeRecord = initializeRecord;
    //        asyncInitializeListResponse retVal = ((NetSuitePortType)(this)).asyncInitializeList(inValue);
    //        asyncStatusResult = retVal.asyncStatusResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<asyncInitializeListResponse> NetSuitePortType.asyncInitializeListAsync(asyncInitializeListRequest request)
    //    {
    //        return base.Channel.asyncInitializeListAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<asyncInitializeListResponse> asyncInitializeListAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, InitializeRecord[] initializeRecord)
    //    {
    //        asyncInitializeListRequest inValue = new asyncInitializeListRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.initializeRecord = initializeRecord;
    //        return ((NetSuitePortType)(this)).asyncInitializeListAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    asyncSearchResponse NetSuitePortType.asyncSearch(asyncSearchRequest request)
    //    {
    //        return base.Channel.asyncSearch(request);
    //    }

    //    public DocumentInfo asyncSearch(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, SearchPreferences searchPreferences, SearchRecord searchRecord, out AsyncStatusResult asyncStatusResult)
    //    {
    //        asyncSearchRequest inValue = new asyncSearchRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.searchPreferences = searchPreferences;
    //        inValue.searchRecord = searchRecord;
    //        asyncSearchResponse retVal = ((NetSuitePortType)(this)).asyncSearch(inValue);
    //        asyncStatusResult = retVal.asyncStatusResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<asyncSearchResponse> NetSuitePortType.asyncSearchAsync(asyncSearchRequest request)
    //    {
    //        return base.Channel.asyncSearchAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<asyncSearchResponse> asyncSearchAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, SearchPreferences searchPreferences, SearchRecord searchRecord)
    //    {
    //        asyncSearchRequest inValue = new asyncSearchRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.searchPreferences = searchPreferences;
    //        inValue.searchRecord = searchRecord;
    //        return ((NetSuitePortType)(this)).asyncSearchAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getAsyncResultResponse NetSuitePortType.getAsyncResult(getAsyncResultRequest request)
    //    {
    //        return base.Channel.getAsyncResult(request);
    //    }

    //    public DocumentInfo getAsyncResult(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, string jobId, int pageIndex, out AsyncResult asyncResult)
    //    {
    //        getAsyncResultRequest inValue = new getAsyncResultRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.jobId = jobId;
    //        inValue.pageIndex = pageIndex;
    //        getAsyncResultResponse retVal = ((NetSuitePortType)(this)).getAsyncResult(inValue);
    //        asyncResult = retVal.asyncResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getAsyncResultResponse> NetSuitePortType.getAsyncResultAsync(getAsyncResultRequest request)
    //    {
    //        return base.Channel.getAsyncResultAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getAsyncResultResponse> getAsyncResultAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, string jobId, int pageIndex)
    //    {
    //        getAsyncResultRequest inValue = new getAsyncResultRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.jobId = jobId;
    //        inValue.pageIndex = pageIndex;
    //        return ((NetSuitePortType)(this)).getAsyncResultAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    checkAsyncStatusResponse NetSuitePortType.checkAsyncStatus(checkAsyncStatusRequest request)
    //    {
    //        return base.Channel.checkAsyncStatus(request);
    //    }

    //    public DocumentInfo checkAsyncStatus(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, string jobId, out AsyncStatusResult asyncStatusResult)
    //    {
    //        checkAsyncStatusRequest inValue = new checkAsyncStatusRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.jobId = jobId;
    //        checkAsyncStatusResponse retVal = ((NetSuitePortType)(this)).checkAsyncStatus(inValue);
    //        asyncStatusResult = retVal.asyncStatusResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<checkAsyncStatusResponse> NetSuitePortType.checkAsyncStatusAsync(checkAsyncStatusRequest request)
    //    {
    //        return base.Channel.checkAsyncStatusAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<checkAsyncStatusResponse> checkAsyncStatusAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, string jobId)
    //    {
    //        checkAsyncStatusRequest inValue = new checkAsyncStatusRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.jobId = jobId;
    //        return ((NetSuitePortType)(this)).checkAsyncStatusAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getDeletedResponse NetSuitePortType.getDeleted(getDeletedRequest request)
    //    {
    //        return base.Channel.getDeleted(request);
    //    }

    //    public DocumentInfo getDeleted(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, GetDeletedFilter getDeletedFilter, int pageIndex, out GetDeletedResult getDeletedResult)
    //    {
    //        getDeletedRequest inValue = new getDeletedRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.getDeletedFilter = getDeletedFilter;
    //        inValue.pageIndex = pageIndex;
    //        getDeletedResponse retVal = ((NetSuitePortType)(this)).getDeleted(inValue);
    //        getDeletedResult = retVal.getDeletedResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getDeletedResponse> NetSuitePortType.getDeletedAsync(getDeletedRequest request)
    //    {
    //        return base.Channel.getDeletedAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getDeletedResponse> getDeletedAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences, GetDeletedFilter getDeletedFilter, int pageIndex)
    //    {
    //        getDeletedRequest inValue = new getDeletedRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        inValue.preferences = preferences;
    //        inValue.getDeletedFilter = getDeletedFilter;
    //        inValue.pageIndex = pageIndex;
    //        return ((NetSuitePortType)(this)).getDeletedAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getAccountGovernanceInfoResponse NetSuitePortType.getAccountGovernanceInfo(getAccountGovernanceInfoRequest request)
    //    {
    //        return base.Channel.getAccountGovernanceInfo(request);
    //    }

    //    public DocumentInfo getAccountGovernanceInfo(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, out GetAccountGovernanceInfoResult getAccountGovernanceInfoResult)
    //    {
    //        getAccountGovernanceInfoRequest inValue = new getAccountGovernanceInfoRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        getAccountGovernanceInfoResponse retVal = ((NetSuitePortType)(this)).getAccountGovernanceInfo(inValue);
    //        getAccountGovernanceInfoResult = retVal.getAccountGovernanceInfoResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getAccountGovernanceInfoResponse> NetSuitePortType.getAccountGovernanceInfoAsync(getAccountGovernanceInfoRequest request)
    //    {
    //        return base.Channel.getAccountGovernanceInfoAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getAccountGovernanceInfoResponse> getAccountGovernanceInfoAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo)
    //    {
    //        getAccountGovernanceInfoRequest inValue = new getAccountGovernanceInfoRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        return ((NetSuitePortType)(this)).getAccountGovernanceInfoAsync(inValue);
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    getIntegrationGovernanceInfoResponse NetSuitePortType.getIntegrationGovernanceInfo(getIntegrationGovernanceInfoRequest request)
    //    {
    //        return base.Channel.getIntegrationGovernanceInfo(request);
    //    }

    //    public DocumentInfo getIntegrationGovernanceInfo(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, out GetIntegrationGovernanceInfoResult getIntegrationGovernanceInfoResult)
    //    {
    //        getIntegrationGovernanceInfoRequest inValue = new getIntegrationGovernanceInfoRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        getIntegrationGovernanceInfoResponse retVal = ((NetSuitePortType)(this)).getIntegrationGovernanceInfo(inValue);
    //        getIntegrationGovernanceInfoResult = retVal.getIntegrationGovernanceInfoResult;
    //        return retVal.documentInfo;
    //    }

    //    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    //    System.Threading.Tasks.Task<getIntegrationGovernanceInfoResponse> NetSuitePortType.getIntegrationGovernanceInfoAsync(getIntegrationGovernanceInfoRequest request)
    //    {
    //        return base.Channel.getIntegrationGovernanceInfoAsync(request);
    //    }

    //    public System.Threading.Tasks.Task<getIntegrationGovernanceInfoResponse> getIntegrationGovernanceInfoAsync(TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo)
    //    {
    //        getIntegrationGovernanceInfoRequest inValue = new getIntegrationGovernanceInfoRequest();
    //        inValue.tokenPassport = tokenPassport;
    //        inValue.applicationInfo = applicationInfo;
    //        inValue.partnerInfo = partnerInfo;
    //        return ((NetSuitePortType)(this)).getIntegrationGovernanceInfoAsync(inValue);
    //    }
    //}
}
