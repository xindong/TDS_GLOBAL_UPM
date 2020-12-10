//
//  NSString+Tools.h
//  TDS
//
//  Created by JiangJiahao on 2018/4/24.
//  Copyright © 2018年 dyy. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface NSString (Tools)
- (NSString *)URLEncodedString;
- (NSString *)URLDecodedString;
///反转字符串
- (NSString *)reverse;

// MD5 hash of the file on the filesystem specified by path
+ (NSString *) stringWithMD5OfFile: (NSString *) path;
// The string's MD5 hash
- (NSString *) MD5Hash;

// base64
- (NSString *)base64Encode;
- (NSString *)base64Dencode;

@end
